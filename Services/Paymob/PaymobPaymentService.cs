
using Microsoft.AspNetCore.Mvc;
using PaymentGateways.Services.DTOs;
using PaymentGateways.Services.Paymob.DTOs.Login;
using PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
using PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;
using System.Text;
using System.Text.Json;

namespace PaymentGateways.Services.Paymob;
public class PaymobPaymentService : BasePaymentService, IPaymentGateway
{
    private readonly List<int> _integrationsIds = new List<int>();
    private readonly string _baseURL;
    private readonly IConfiguration _configuration;

    public PaymobPaymentService(HttpClient httpClient, IConfiguration configuration) : base(httpClient)
    {
        _configuration = configuration;
        _integrationsIds = [5261324];
        _baseURL = _configuration["Paymob:BaseURL"];
    }
    public async Task<ApiResponseDTO<InvoiceLinkResponseDTO>> SendPayment(InvoiceLinkRequestDTO invoiceLinkRequestDTO)
    {
        try
        {
            string token = await GenerateToken();

            invoiceLinkRequestDTO.APISource = "INVOICE";
            invoiceLinkRequestDTO.Integrations = _integrationsIds;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (token != null)
            {
                headers.Add("Authorization", $"Bearer {token}");
            }

            var response = 
                await BuildRequestAsync<InvoiceLinkResponseDTO>(HttpMethod.Post, _baseURL+"/api/ecommerce/orders", invoiceLinkRequestDTO, headers);
            
            return response;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<string> GenerateToken()
    {
        try
        {
            PaymobLoginRequestDTO data = new PaymobLoginRequestDTO
            {
                APIKey = _configuration["Paymob:APIKey"]
            };

            ApiResponseDTO<PaymobLoginResponseDTO> response = 
                await BuildRequestAsync<PaymobLoginResponseDTO>(HttpMethod.Post, _baseURL + "/api/auth/tokens", data);

            return response.Data.Token;
        }
        catch
        {
            throw;
        }
    }

    public bool TransactionProcessedCallback(PaymobTransactionCallbackDTO request)
    {
        if (request.Obj.Success)
            return true;
        return false;
    }
}
