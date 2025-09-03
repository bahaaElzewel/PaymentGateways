using Microsoft.AspNetCore.Mvc;
using PaymentGateways.Services;
using PaymentGateways.Services.Hmac;
using PaymentGateways.Services.Paymob.DTOs.Payment.Callback;
using PaymentGateways.Services.Paymob.DTOs.Payment.InvoiceLink;

namespace PaymentGateways.Controllers
{
    public class PaymobController : ControllerBase
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly IAcceptHmac _acceptHmac;

        public PaymobController(IPaymentGateway paymentGateway, IAcceptHmac acceptHmac)
        {
            _paymentGateway = paymentGateway;
            _acceptHmac = acceptHmac;
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromBody] InvoiceLinkRequestDTO request)
        {
            try
            {
                var result = await _paymentGateway.SendPayment(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        [HttpPost("TransactionProcessedCallback")]
        public IActionResult TransactionProcessedCallback([FromBody] PaymobTransactionCallbackDTO request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(kv => kv.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kv => kv.Key,
                        kv => kv.Value!.Errors.Select(e => e.ErrorMessage).ToArray());

                // Return the exact failing paths (property names) and messages
                return BadRequest(new { message = "Model binding failed", errors });
            }

            try
            {
                bool result = _paymentGateway.TransactionProcessedCallback(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        [HttpGet("SuccessCallback")]
        public async Task<IActionResult> SuccessCallback()
        {
            var x= await _acceptHmac.PaymobValidateAsync(Request, Services.Paymob.Enums.PaymobAcceptCallbackType.TransactionProcessed);
            return Ok(x);
        }
    }
}
