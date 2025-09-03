using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class MigsOrderDTO
{
    [JsonPropertyName("acceptPartialAmount")]
    public bool AcceptPartialAmount { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("authenticationStatus")]
    public string AuthenticationStatus { get; set; } = default!;

    [JsonPropertyName("chargeback")]
    public ChargebackDTO Chargeback { get; set; } = default!;

    [JsonPropertyName("creationTime")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("lastUpdatedTime")]
    public DateTime LastUpdatedTime { get; set; }

    [JsonPropertyName("merchantAmount")]
    public double MerchantAmount { get; set; }

    [JsonPropertyName("merchantCategoryCode")]
    public string MerchantCategoryCode { get; set; } = default!;

    [JsonPropertyName("merchantCurrency")]
    public string MerchantCurrency { get; set; } = default!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("totalAuthorizedAmount")]
    public double TotalAuthorizedAmount { get; set; }

    [JsonPropertyName("totalCapturedAmount")]
    public double TotalCapturedAmount { get; set; }

    [JsonPropertyName("totalRefundedAmount")]
    public double? TotalRefundedAmount { get; set; }
}
