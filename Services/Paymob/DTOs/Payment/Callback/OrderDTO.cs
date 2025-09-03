using PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;
using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class OrderDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("delivery_needed")]
    public bool DeliveryNeeded { get; set; }

    [JsonPropertyName("merchant")]
    public MerchantDTO Merchant { get; set; } = default!;

    [JsonPropertyName("collector")]
    public object? Collector { get; set; }

    [JsonPropertyName("amount_cents")]
    public long AmountCents { get; set; }

    [JsonPropertyName("shipping_data")]
    public ShippingDataDTO ShippingData { get; set; } = default!;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;

    [JsonPropertyName("is_payment_locked")]
    public bool IsPaymentLocked { get; set; }

    [JsonPropertyName("is_return")]
    public bool IsReturn { get; set; }

    [JsonPropertyName("is_cancel")]
    public bool IsCancel { get; set; }

    [JsonPropertyName("is_returned")]
    public bool IsReturned { get; set; }

    [JsonPropertyName("is_canceled")]
    public bool IsCanceled { get; set; }

    [JsonPropertyName("merchant_order_id")]
    public object? MerchantOrderId { get; set; }

    [JsonPropertyName("wallet_notification")]
    public object? WalletNotification { get; set; }

    [JsonPropertyName("paid_amount_cents")]
    public long PaidAmountCents { get; set; }

    [JsonPropertyName("notify_user_with_email")]
    public bool NotifyUserWithEmail { get; set; }

    [JsonPropertyName("items")]
    public List<object> Items { get; set; } = new();

    [JsonPropertyName("order_url")]
    public string OrderUrl { get; set; } = default!;

    [JsonPropertyName("commission_fees")]
    public object? CommissionFees { get; set; }

    [JsonPropertyName("delivery_fees_cents")]
    public object? DeliveryFeesCents { get; set; }

    [JsonPropertyName("delivery_vat_cents")]
    public object? DeliveryVatCents { get; set; }

    [JsonPropertyName("payment_method")]
    public string PaymentMethod { get; set; } = default!;

    [JsonPropertyName("merchant_staff_tag")]
    public object? MerchantStaffTag { get; set; }

    [JsonPropertyName("api_source")]
    public string ApiSource { get; set; } = default!;

    [JsonPropertyName("data")]
    public Dictionary<string, object> Data { get; set; } = new();
}
