using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;

public class ItemDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("amount_cents")]
    public int AmountCents { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}
