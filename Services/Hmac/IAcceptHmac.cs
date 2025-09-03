using PaymentGateways.Services.Paymob.Enums;
using System.Threading.Tasks;

namespace PaymentGateways.Services.Hmac;
public interface IAcceptHmac
{
    Task<AcceptHmacResult> PaymobValidateAsync(HttpRequest request, PaymobAcceptCallbackType callbackType);
}
