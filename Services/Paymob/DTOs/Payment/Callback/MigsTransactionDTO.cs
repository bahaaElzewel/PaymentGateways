using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class MigsTransactionDTO
{
    [JsonPropertyName("acquirer")]
    public AcquirerDTO Acquirer { get; set; } = default!;

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("authenticationStatus")]
    public string AuthenticationStatus { get; set; } = default!;

    [JsonPropertyName("authorizationCode")]
    public string AuthorizationCode { get; set; } = default!;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("receipt")]
    public string Receipt { get; set; } = default!;

    [JsonPropertyName("source")]
    public string Source { get; set; } = default!;

    [JsonPropertyName("stan")]
    public string Stan { get; set; } = default!;

    [JsonPropertyName("terminal")]
    public string Terminal { get; set; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;
}
