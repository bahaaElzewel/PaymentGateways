using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;

public class InvoiceLinkRequestDTO
{
    [JsonPropertyName("api_source")]
    public string APISource { get; set; } = default!;
    
    [JsonPropertyName("amount_cents")]
    public string AmountCents { get; set; } = default!;
    
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;
    
    [JsonPropertyName("shipping_data")]
    public ShippingDataDTO ShippingData { get; set; } = default!;
    
    [JsonPropertyName("integrations")]
    public List<int> Integrations { get; set; } = [];

    [JsonPropertyName("items")]
    public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();

    [JsonPropertyName("delivery_needed")]
    public bool DeliveryNeeded { get; set; }
}
