using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Application.Abstractions.IPaymentGatewayService;

public interface IPaymentGatewayService
{
    public AppOrder CreateOrder(AppOrder model);

    public Task<AppPayment> CapturePayment(PaymentDetailsRequest model);


    public Task<IEnumerable<PaymentRefundResponse>> RefundPayment(IEnumerable<string> rpPaymnetIds);

}
