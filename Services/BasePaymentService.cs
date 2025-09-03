using PaymentGateways.Services.DTOs;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaymentGateways.Services;

public class BasePaymentService
{
    protected readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        // You can add Converters here if needed
        // Converters = { new JsonStringEnumConverter() }
    };

    public BasePaymentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<ApiResponseDTO<T>> BuildRequestAsync<T>(HttpMethod method, string url, object? body = null, Dictionary<string, string>? headers = null)
    {
        using HttpRequestMessage request = new HttpRequestMessage(method, url);

        if (body is not null && method != HttpMethod.Get && method != HttpMethod.Head)
        {
            var json = JsonSerializer.Serialize(body, _jsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        if (headers is not null)
        {
            foreach (var kv in headers)
                request.Headers.TryAddWithoutValidation(kv.Key, kv.Value);
        }


        using HttpResponseMessage response = await _httpClient.SendAsync(request);
        string payload = await response.Content.ReadAsStringAsync();

        ApiResponseDTO<T> wrapper = new ApiResponseDTO<T>
        {
            StatusCode = (int)response.StatusCode,
            IsSuccess = response.IsSuccessStatusCode
        };

        if (typeof(T) == typeof(string))
        {
            // Return raw payload without JSON parse
            wrapper.Data = (T)(object)payload;
            return wrapper;
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"HTTP {(int)response.StatusCode} {response.ReasonPhrase}. Body: {payload}");
        }

        try
        {
            wrapper.Data = await DeserializeWithDiagnostics<T>(payload, _jsonOptions);
            return wrapper;
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"Failed to deserialize response to {typeof(T).Name}. Body: {payload}", ex);
        }
    }

    private static string SnipUtf8(byte[] utf8, long bytePos, int context = 60)
    {
        // Make sure indices are inside the array
        var start = (int)Math.Max(0, bytePos - context);
        var len = (int)Math.Min(context * 2, utf8.Length - start);
        return Encoding.UTF8.GetString(utf8, start, len);
    }

    protected async Task<T?> DeserializeWithDiagnostics<T>(string payload, JsonSerializerOptions opts)
    {
        // Work with UTF8 bytes so BytePositionInLine maps exactly
        var bytes = Encoding.UTF8.GetBytes(payload);
        try
        {
            return JsonSerializer.Deserialize<T>(bytes, opts);
        }
        catch (JsonException ex)
        {
            var snippet = SnipUtf8(bytes, (long)ex.BytePositionInLine);
            throw new InvalidOperationException(
                $"Failed to deserialize to {typeof(T).Name} at path '{ex.Path}' " +
                $"(line {ex.LineNumber}, byte {ex.BytePositionInLine}). " +
                $"Message: {ex.Message}\nContext: …{snippet}…",
                ex);
        }
    }
}
