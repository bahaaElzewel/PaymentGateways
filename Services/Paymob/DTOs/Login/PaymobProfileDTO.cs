using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Login;

public class PaymobProfileDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("user")]
    public PaymobUserDTO User { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("profile_type")]
    public string ProfileType { get; set; } = default!;

    [JsonPropertyName("phones")]
    public List<string> Phones { get; set; } = new();

    [JsonPropertyName("company_emails")]
    public List<string>? CompanyEmails { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("email_notification")]
    public bool EmailNotification { get; set; }

    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("is_mobadra")]
    public bool IsMobadra { get; set; }

    [JsonPropertyName("sector")]
    public string? Sector { get; set; }

    [JsonPropertyName("is_2fa_enabled")]
    public bool Is2faEnabled { get; set; }

    [JsonPropertyName("otp_sent_to")]
    public string? OtpSentTo { get; set; }

    [JsonPropertyName("activation_method")]
    public int ActivationMethod { get; set; }

    [JsonPropertyName("signed_up_through")]
    public int? SignedUpThrough { get; set; }

    [JsonPropertyName("failed_attempts")]
    public int? FailedAttempts { get; set; }

    [JsonPropertyName("custom_export_columns")]
    public List<string> CustomExportColumns { get; set; } = new();

    [JsonPropertyName("server_IP")]
    public List<string> ServerIP { get; set; } = new();

    [JsonPropertyName("primary_phone_number")]
    public string? PrimaryPhoneNumber { get; set; }

    [JsonPropertyName("primary_phone_verified")]
    public bool PrimaryPhoneVerified { get; set; }

    [JsonPropertyName("is_temp_password")]
    public bool IsTempPassword { get; set; }

    [JsonPropertyName("otp_sent_at")]
    public DateTime? OtpSentAt { get; set; }

    [JsonPropertyName("otp_validated_at")]
    public DateTime? OtpValidatedAt { get; set; }

    [JsonPropertyName("delivery_status_callback")]
    public string? DeliveryStatusCallback { get; set; }

    [JsonPropertyName("merchant_status")]
    public int? MerchantStatus { get; set; }

    [JsonPropertyName("deactivated_by_bank")]
    public bool DeactivatedByBank { get; set; }

    [JsonPropertyName("bank_merchant_status")]
    public int? BankMerchantStatus { get; set; }

    [JsonPropertyName("bank_received_documents")]
    public bool BankReceivedDocuments { get; set; }

    [JsonPropertyName("filled_business_data")]
    public bool FilledBusinessData { get; set; }

    [JsonPropertyName("day_start_time")]
    public string? DayStartTime { get; set; }

    [JsonPropertyName("day_end_time")]
    public string? DayEndTime { get; set; }

    [JsonPropertyName("withhold_transfers")]
    public bool WithholdTransfers { get; set; }

    [JsonPropertyName("sms_sender_name")]
    public string? SmsSenderName { get; set; }

    [JsonPropertyName("can_bill_deposit_with_card")]
    public bool CanBillDepositWithCard { get; set; }

    [JsonPropertyName("can_topup_merchants")]
    public bool CanTopupMerchants { get; set; }

    [JsonPropertyName("referral_eligible")]
    public bool ReferralEligible { get; set; }

    [JsonPropertyName("is_ranger")]
    public bool IsRanger { get; set; }

    [JsonPropertyName("is_poaching")]
    public bool IsPoaching { get; set; }

    [JsonPropertyName("paymob_app_merchant")]
    public bool PaymobAppMerchant { get; set; }

    [JsonPropertyName("allow_transaction_notifications")]
    public bool AllowTransactionNotifications { get; set; }

    [JsonPropertyName("allow_transfer_notifications")]
    public bool AllowTransferNotifications { get; set; }

    [JsonPropertyName("payout_enabled")]
    public bool PayoutEnabled { get; set; }

    [JsonPropertyName("payout_terms")]
    public bool PayoutTerms { get; set; }

    [JsonPropertyName("is_bills_new")]
    public bool IsBillsNew { get; set; }

    [JsonPropertyName("can_process_multiple_refunds")]
    public bool CanProcessMultipleRefunds { get; set; }

    [JsonPropertyName("instant_settlement_enabled")]
    public bool InstantSettlementEnabled { get; set; }

    [JsonPropertyName("instant_settlement_transaction_otp_verified")]
    public bool InstantSettlementTransactionOtpVerified { get; set; }

    [JsonPropertyName("preferred_language")]
    public string? PreferredLanguage { get; set; }

    [JsonPropertyName("ignore_flash_callbacks")]
    public bool IgnoreFlashCallbacks { get; set; }

    [JsonPropertyName("permissions")]
    public List<object> Permissions { get; set; } = new();
}
