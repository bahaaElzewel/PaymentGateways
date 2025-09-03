using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class BillingDataDTO
{
    [JsonPropertyName("city")]
    public string City { get; set; } = default!;

    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("floor")]
    public string Floor { get; set; } = default!;

    [JsonPropertyName("state")]
    public string State { get; set; } = default!;

    [JsonPropertyName("street")]
    public string Street { get; set; } = default!;

    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;

    [JsonPropertyName("building")]
    public string Building { get; set; } = default!;

    [JsonPropertyName("apartment")]
    public string Apartment { get; set; } = default!;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = default!;

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = default!;

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; } = default!;

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = default!;

    [JsonPropertyName("extra_description")]
    public string ExtraDescription { get; set; } = default!;
}
