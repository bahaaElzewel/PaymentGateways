namespace PaymentGateways.Services.Hmac;

public sealed class AcceptHmacResult
{
    public bool IsValid { get; init; }
    public string ProvidedHmac { get; init; } = "";
    public string ComputedHmac { get; init; } = "";
    public string CanonicalString { get; init; } = "";
}
