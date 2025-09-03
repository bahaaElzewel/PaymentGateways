using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Login;
public class PaymobUserDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; } = default!;

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = default!;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = default!;

    [JsonPropertyName("date_joined")]
    public DateTime DateJoined { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("is_staff")]
    public bool IsStaff { get; set; }

    [JsonPropertyName("is_superuser")]
    public bool IsSuperuser { get; set; }

    [JsonPropertyName("last_login")]
    public DateTime? LastLogin { get; set; }

    [JsonPropertyName("groups")]
    public List<object> Groups { get; set; } = new();

    [JsonPropertyName("user_permissions")]
    public List<int> UserPermissions { get; set; } = new();
}
