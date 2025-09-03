using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;
public class InvoiceLinkResponseDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("delivery_needed")]
    public bool DeliveryNeeded { get; set; }

    [JsonPropertyName("merchant")]
    public MerchantDTO Merchant { get; set; } = default!;

    [JsonPropertyName("collector")]
    public object? Collector { get; set; }

    [JsonPropertyName("amount_cents")]
    public int AmountCents { get; set; }

    [JsonPropertyName("shipping_data")]
    public ShippingDataDTO ShippingData { get; set; } = default!;

    [JsonPropertyName("shipping_details")]
    public object? ShippingDetails { get; set; }

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
    public int? PaidAmountCents { get; set; }

    [JsonPropertyName("notify_user_with_email")]
    public bool NotifyUserWithEmail { get; set; }

    [JsonPropertyName("items")]
    public List<ItemDTO> Items { get; set; } = new();

    [JsonPropertyName("order_url")]
    public string OrderUrl { get; set; } = default!;

    [JsonPropertyName("commission_fees")]
    public object? CommissionFees { get; set; }

    [JsonPropertyName("delivery_fees_cents")]
    public int? DeliveryFeesCents { get; set; }

    [JsonPropertyName("delivery_vat_cents")]
    public int? DeliveryVatCents { get; set; }

    [JsonPropertyName("payment_method")]
    public string PaymentMethod { get; set; } = default!;

    [JsonPropertyName("merchant_staff_tag")]
    public object? MerchantStaffTag { get; set; }

    [JsonPropertyName("api_source")]
    public string ApiSource { get; set; } = default!;

    [JsonPropertyName("pickup_data")]
    public object? PickupData { get; set; }

    [JsonPropertyName("delivery_status")]
    public List<object> DeliveryStatus { get; set; } = new();

    [JsonPropertyName("data")]
    public Dictionary<string, object> Data { get; set; } = new();

    [JsonPropertyName("token")]
    public string Token { get; set; } = default!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = default!;
}
