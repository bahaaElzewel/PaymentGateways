using System.Text.Json.Serialization;

namespace PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
public class TransactionDataDTO
{
    [JsonPropertyName("gateway_integration_pk")]
    public long GatewayIntegrationPk { get; set; }

    [JsonPropertyName("klass")]
    public string Klass { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;

    [JsonPropertyName("migs_order")]
    public MigsOrderDTO MigsOrder { get; set; } = default!;

    [JsonPropertyName("merchant")]
    public string Merchant { get; set; } = default!;

    [JsonPropertyName("migs_result")]
    public string MigsResult { get; set; } = default!;

    [JsonPropertyName("migs_transaction")]
    public MigsTransactionDTO MigsTransaction { get; set; } = default!;

    [JsonPropertyName("txn_response_code")]
    public string TxnResponseCode { get; set; } = default!;

    [JsonPropertyName("acq_response_code")]
    public string AcqResponseCode { get; set; } = default!;

    [JsonPropertyName("message")]
    public string Message { get; set; } = default!;

    [JsonPropertyName("merchant_txn_ref")]
    public string MerchantTxnRef { get; set; } = default!;

    [JsonPropertyName("order_info")]
    public string OrderInfo { get; set; } = default!;

    [JsonPropertyName("receipt_no")]
    public string ReceiptNo { get; set; } = default!;

    [JsonPropertyName("transaction_no")]
    public string TransactionNo { get; set; } = default!;

    [JsonPropertyName("batch_no")]
    public int BatchNo { get; set; }

    [JsonPropertyName("authorize_id")]
    public string AuthorizeId { get; set; } = default!;

    [JsonPropertyName("card_type")]
    public string CardType { get; set; } = default!;

    [JsonPropertyName("card_num")]
    public string CardNum { get; set; } = default!;

    [JsonPropertyName("secure_hash")]
    public string SecureHash { get; set; } = default!;

    [JsonPropertyName("avs_result_code")]
    public string AvsResultCode { get; set; } = default!;

    [JsonPropertyName("avs_acq_response_code")]
    public string AvsAcqResponseCode { get; set; } = default!;

    [JsonPropertyName("captured_amount")]
    public double CapturedAmount { get; set; }

    [JsonPropertyName("authorised_amount")]
    public double AuthorisedAmount { get; set; }

    [JsonPropertyName("refunded_amount")]
    public double? RefundedAmount { get; set; }

    [JsonPropertyName("acs_eci")]
    public string AcsEci { get; set; } = default!;
}
