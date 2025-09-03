using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class SourceDataDTO
{
    [JsonPropertyName("pan")]
    public string Pan { get; set; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("tenure")]
    public string? Tenure { get; set; }

    [JsonPropertyName("sub_type")]
    public string SubType { get; set; } = default!;
}
