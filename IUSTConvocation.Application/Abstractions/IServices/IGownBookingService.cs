using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;


namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IGownBookingService
{
    Task<APIResponse<AppOrderResponse>> BookGown(AppOrderRequest model);


    Task<APIResponse<PaymentDetailsResponse>> CapturePaymentDetails(PaymentDetailsRequest model);

    //Task<ApiResponse<string>> RefundPayment(UserPaymentRefundRequest model);
    Task<APIResponse<IEnumerable<GownBookingResponse>>> GetBookingsByGownId(Guid id);

     Task<APIResponse<StudentBookingGownResponse>> GetMyBookings();
  
    Task<APIResponse<IEnumerable<StudentGownBookingsResponse>>> GetGownBookings(Guid convocationId);

    Task<APIResponse<int>> TotalSalesAmountByGownId(Guid gownId);

}
