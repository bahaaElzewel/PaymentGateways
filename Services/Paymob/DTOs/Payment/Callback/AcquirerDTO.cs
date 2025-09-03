using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class AcquirerDTO
{
    [JsonPropertyName("batch")]
    public long Batch { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; } = default!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; } = default!;

    [JsonPropertyName("settlementDate")]
    public DateTime SettlementDate { get; set; }

    [JsonPropertyName("timeZone")]
    public string TimeZone { get; set; } = default!;

    [JsonPropertyName("transactionId")]
    public string TransactionId { get; set; } = default!;
}
