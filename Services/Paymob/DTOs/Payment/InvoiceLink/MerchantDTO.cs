using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;
public class MerchantDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("phones")]
    public List<string> Phones { get; set; } = new();

    [JsonPropertyName("company_emails")]
    public List<string> CompanyEmails { get; set; } = new();

    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; } = default!;

    [JsonPropertyName("state")]
    public string State { get; set; } = default!;

    [JsonPropertyName("country")]
    public string Country { get; set; } = default!;

    [JsonPropertyName("city")]
    public string City { get; set; } = default!;

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; } = default!;

    [JsonPropertyName("street")]
    public string Street { get; set; } = default!;
}
