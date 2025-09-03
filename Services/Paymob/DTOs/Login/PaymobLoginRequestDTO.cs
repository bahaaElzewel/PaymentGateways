using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Login;
public class PaymobLoginRequestDTO
{
    [JsonPropertyName("api_key")]
    public string APIKey { get; set; } = null!;
}
