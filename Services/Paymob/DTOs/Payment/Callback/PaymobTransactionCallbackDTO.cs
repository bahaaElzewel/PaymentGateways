using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;

public class PaymobTransactionCallbackDTO
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("obj")]
    public TransactionObjDTO Obj { get; set; } = default!;

    [JsonPropertyName("issuer_bank")]
    public string? IssuerBank { get; set; }

    [JsonPropertyName("transaction_processed_callback_responses")]
    public string? TransactionProcessedCallbackResponses { get; set; }
}
