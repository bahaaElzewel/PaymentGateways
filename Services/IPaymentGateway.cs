using Microsoft.AspNetCore.Mvc;
using PaymentGateways.Services.DTOs;
using PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
using PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;

namespace PaymentGateways.Services
{
    public interface IPaymentGateway
    {
        Task<ApiResponseDTO<InvoiceLinkResponseDTO>> SendPayment(InvoiceLinkRequestDTO paymentRequestDTO);
        bool TransactionProcessedCallback(PaymobTransactionCallbackDTO request);
    }
}
