using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class PaymentKeyClaimsDTO
{
    [JsonPropertyName("extra")]
    public Dictionary<string, object> Extra { get; set; } = new();

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;

    [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    [JsonPropertyName("amount_cents")]
    public long AmountCents { get; set; }

    [JsonPropertyName("billing_data")]
    public BillingDataDTO BillingData { get; set; } = default!;

    [JsonPropertyName("redirect_url")]
    public string RedirectUrl { get; set; } = default!;

    [JsonPropertyName("integration_id")]
    public long IntegrationId { get; set; }

    [JsonPropertyName("lock_order_when_paid")]
    public bool LockOrderWhenPaid { get; set; }

    [JsonPropertyName("next_payment_intention")]
    public string NextPaymentIntention { get; set; } = default!;

    [JsonPropertyName("single_payment_attempt")]
    public bool SinglePaymentAttempt { get; set; }
}
