using PaymentGateways.Services.Paymob.Enums;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PaymentGateways.Services.Hmac;
public class AcceptHmac : IAcceptHmac
{
    private readonly string _secret;

    private static readonly string[] TxProcessedOrder = new[]
    {
        "amount_cents",
        "created_at",
        "currency",
        "error_occured",
        "has_parent_transaction",
        "id",
        "integration_id",
        "is_3d_secure",
        "is_auth",
        "is_capture",
        "is_refunded",
        "is_standalone_payment",
        "is_voided",
        "order",
        "owner",
        "pending",
        "source_data.pan",
        "source_data.sub_type",
        "source_data.type",
        "success"
    };

    public AcceptHmac(IConfiguration configuration)
    {
        _secret = configuration["Paymob:Hmac"] ?? "";
        if (string.IsNullOrWhiteSpace(_secret))
            throw new ArgumentNullException(nameof(_secret), "Paymob:Hmac not configured.");
    }

    public async Task<AcceptHmacResult> PaymobValidateAsync(HttpRequest request, PaymobAcceptCallbackType callbackType)
    {
        var kv = new Dictionary<string, string?>(StringComparer.Ordinal);

        foreach (var (k, v) in request.Query)
            if (!k.Equals("hmac", StringComparison.OrdinalIgnoreCase))
                kv[k] = v.ToString();

        // Keep POST support (some Accept callbacks are POST)
        if (HttpMethods.IsPost(request.Method))
        {
            if (request.HasFormContentType)
            {
                var form = await request.ReadFormAsync();
                foreach (var (k, v) in form)
                    if (!k.Equals("hmac", StringComparison.OrdinalIgnoreCase))
                        kv[k] = v.ToString();
            }
            else if (request.ContentType?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true)
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body, Encoding.UTF8, false, leaveOpen: true);
                var body = await reader.ReadToEndAsync();
                request.Body.Position = 0;

                if (!string.IsNullOrWhiteSpace(body))
                {
                    using var doc = JsonDocument.Parse(body);
                    foreach (var prop in doc.RootElement.EnumerateObject())
                    {
                        if (prop.Name.Equals("hmac", StringComparison.OrdinalIgnoreCase)) continue;
                        kv[prop.Name] = prop.Value.ValueKind switch
                        {
                            JsonValueKind.Null => "",
                            JsonValueKind.String => prop.Value.GetString(),
                            JsonValueKind.Number => prop.Value.ToString(),
                            JsonValueKind.True => "true",
                            JsonValueKind.False => "false",
                            _ => prop.Value.ToString()
                        };
                    }
                }
            }
        }

        // 2) Provided HMAC (query first for GET, then fallback to POST sources)
        string providedHmac = request.Query["hmac"];
        if (string.IsNullOrEmpty(providedHmac) && HttpMethods.IsPost(request.Method))
        {
            if (request.HasFormContentType)
            {
                var form = await request.ReadFormAsync();
                providedHmac = form["hmac"];
            }
            else if (request.ContentType?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true)
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body, Encoding.UTF8, false, leaveOpen: true);
                var body = await reader.ReadToEndAsync();
                request.Body.Position = 0;

                if (!string.IsNullOrWhiteSpace(body))
                {
                    try
                    {
                        using var doc = JsonDocument.Parse(body);
                        if (doc.RootElement.TryGetProperty("hmac", out var h))
                            providedHmac = h.GetString() ?? "";
                    }
                    catch { /* ignore */ }
                }
            }
        }

        // 3) Canonical string build (values only; in documented order)
        string canonical = callbackType == PaymobAcceptCallbackType.TransactionProcessed
            ? ConcatenateInOrder(kv, TxProcessedOrder)
            : ConcatenateLexicographically(kv); // fallback if you add other callback types later

        // 4) Compute HMAC-SHA512 (lowercase hex)
        string computed = ComputeHmacSha512Hex(canonical, _secret);

        // 5) Constant-time compare
        bool ok = ConstantTimeEqualsAscii(providedHmac, computed);

        return new AcceptHmacResult
        {
            IsValid = ok,
            ProvidedHmac = providedHmac ?? "",
            ComputedHmac = computed,
            CanonicalString = canonical
        };
    }

    private static string ConcatenateInOrder(IReadOnlyDictionary<string, string?> kv, IEnumerable<string> keyOrder)
    {
        var sb = new StringBuilder();
        foreach (var k in keyOrder)
            sb.Append(kv.TryGetValue(k, out var v) ? v ?? "" : "");
        return sb.ToString();
    }

    private static string ConcatenateLexicographically(IReadOnlyDictionary<string, string?> kv)
    {
        var sb = new StringBuilder();
        foreach (var k in kv.Keys.OrderBy(k => k, StringComparer.Ordinal))
            sb.Append(kv[k] ?? "");
        return sb.ToString();
    }

    private static string ComputeHmacSha512Hex(string data, string secret)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        var chars = new char[hash.Length * 2];
        int i = 0;
        foreach (var b in hash)
        {
            chars[i++] = GetHexNibble(b >> 4);
            chars[i++] = GetHexNibble(b & 0xF);
        }
        return new string(chars);

        static char GetHexNibble(int val) => (char)(val < 10 ? ('0' + val) : ('a' + (val - 10)));
    }

    private static bool ConstantTimeEqualsAscii(string? a, string? b)
    {
        if (a is null || b is null) return false;
        string x = a.Trim().ToLowerInvariant();
        string y = b.Trim().ToLowerInvariant();
        if (x.Length != y.Length) return false;
        int diff = 0;
        for (int i = 0; i < x.Length; i++) diff |= x[i] ^ y[i];
        return diff == 0;
    }
}
