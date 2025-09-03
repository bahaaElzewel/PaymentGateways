using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;
public class ShippingDataDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = default!;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = default!;

    [JsonPropertyName("street")]
    public string Street { get; set; } = default!;

    [JsonPropertyName("building")]
    public string Building { get; set; } = default!;

    [JsonPropertyName("floor")]
    public string Floor { get; set; } = default!;

    [JsonPropertyName("apartment")]
    public string Apartment { get; set; } = default!;

    [JsonPropertyName("city")]
    public string City { get; set; } = default!;

    [JsonPropertyName("state")]
    public string State { get; set; } = default!;

    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;

    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = default!;

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; } = default!;

    [JsonPropertyName("extra_description")]
    public string ExtraDescription { get; set; } = default!;

    [JsonPropertyName("shipping_method")]
    public string ShippingMethod { get; set; } = default!;

    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }
}
