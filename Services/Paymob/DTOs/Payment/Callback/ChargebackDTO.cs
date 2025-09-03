using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class ChargebackDTO
{
    [JsonPropertyName("amount")]
    public long? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;
}
