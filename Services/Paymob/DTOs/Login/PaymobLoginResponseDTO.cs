using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Login;

public class PaymobLoginResponseDTO
{
    [JsonPropertyName("profile")]
    public PaymobProfileDTO Profile { get; set; } = default!;

    [JsonPropertyName("token")]
    public string Token { get; set; } = default!;
    [JsonPropertyName("profile_token")]
    public string ProfileToken { get; set; } = null!;
}
