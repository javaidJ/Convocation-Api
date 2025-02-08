using AutoMapper;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IPaymentGatewayService;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IRepository;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;

namespace IUSTConvocation.Application.Services;

public class GownBookingService : IGownBookingService
{
    private readonly IGownBookingRepository repository;
    private readonly IMapper mapper;
    private readonly IFileService fileService;
    private readonly IContextService contextService;
    private readonly IPaymentGatewayService paymentGatewayService;
    private readonly IOrderRepository orderRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IRegistrationService registrationService;

    public GownBookingService(IGownBookingRepository repository, IMapper mapper, IFileService fileService,IContextService contextService,
        IPaymentGatewayService paymentGatewayService,IOrderRepository orderRepository,IStudentRepository studentRepository, IRegistrationService registrationService )
    {
        this.repository = repository;
        this.mapper = mapper;
        this.fileService = fileService;
        this.contextService = contextService;
        this.paymentGatewayService = paymentGatewayService;
        this.orderRepository = orderRepository;
        this.studentRepository = studentRepository;
        this.registrationService = registrationService;
    }

    public async Task<APIResponse<AppOrderResponse>> BookGown(AppOrderRequest model)
    {
        var gown = await repository.FirstOrDefaultAsync<Gown>(x => x.Id == model.GownId && x.IsDeleted == false);

        if (gown is null)
            return APIResponse<AppOrderResponse>.ErrorResponse("No Gown found.", APIStatusCodes.BadRequest);

        var bookedGowns = await repository.FindByAsync<GownBooking>(x => x.GownId == model.GownId);

        if (bookedGowns.Count() >= gown.Quantity)
            return APIResponse<AppOrderResponse>.ErrorResponse("Gown not available", APIStatusCodes.BadRequest);


        var userId = contextService.GetUserId();
        var dbBooking = await repository.FirstOrDefaultAsync<GownBooking>(x => x.EntityId == userId && x.ConvocationId== model.ConvocationId);
        if (dbBooking != null)
            return APIResponse<AppOrderResponse>.ErrorResponse("Booking Already done", APIStatusCodes.AlreadyReported);




        GownBooking booking = new();
        booking.Id = Guid.NewGuid();
        booking.EntityId = userId;
        booking.GownId = model.GownId;
        booking.CreatedBy = contextService.GetUserId();
        booking.GownStatus = GownStatus.Pending;
        booking.ConvocationId=model.ConvocationId;

        if (await repository.InsertAsync(booking) > 0)
        {
            AppOrder userOrder = new();
            userOrder.Id = Guid.NewGuid();
            userOrder.TotalAmount = gown.Charges;

            userOrder.Receipt = new Random().Next(1000, 100000).ToString();

            var appOrder = paymentGatewayService.CreateOrder(userOrder);

            if (appOrder.OrderStatus == AppOrderStatus.Created)
            {
              //  appOrder.Id = Guid.NewGuid();
                appOrder.GownBookingId = booking.Id;
                appOrder.UserId = contextService.GetUserId();

                int returnVal = await orderRepository.SaveOrder(appOrder);

                if (returnVal > 0)
                {
                    var appOrderResponse = mapper.Map<AppOrderResponse>(appOrder);
                    var student = await studentRepository.GetStudentById(userId);
                    appOrderResponse.Name = student.Name;
                    appOrderResponse.Email = student.Email;
                    appOrderResponse.Contact = student.ContactNo;
                    appOrderResponse.FilePath = student.FilePath;
                    appOrderResponse.Amount = userOrder.TotalAmount;
                    appOrderResponse.Receipt = userOrder.Receipt;

                    return APIResponse<AppOrderResponse>.SuccessResponse(appOrderResponse, APIStatusCodes.OK, "Success");
                }
            }
        }
        return APIResponse<AppOrderResponse>.ErrorResponse("Something went wrong", APIStatusCodes.InternalServerError);

    }

    public async Task<APIResponse<PaymentDetailsResponse>> CapturePaymentDetails(PaymentDetailsRequest model)
    {
        var appPayment = await paymentGatewayService.CapturePayment(model);
        var order = await orderRepository.FirstOrDefaultAsync<AppOrder>(e => e.OrderId == model.razorpay_order_id);
        appPayment.OrderId = order!.Id;
        int returnValue = await repository.InsertAsync(appPayment);
        if (returnValue > 0)
        {
            var booking = await repository.GetByIdAsync<GownBooking>(order.GownBookingId);
            if (booking is not null)
            {
                booking.GownStatus = GownStatus.Approved;
                await repository.UpdateAsync(booking);
            }

            return APIResponse<PaymentDetailsResponse>.SuccessResponse(new PaymentDetailsResponse { IsPaymentSuccessfull = true }, APIStatusCodes.OK);

        }

        return APIResponse<PaymentDetailsResponse>.ErrorResponse("There is some issue please try after sometime", APIStatusCodes.InternalServerError);
    }

    public async Task<APIResponse<IEnumerable<GownBookingResponse>>> GetBookingsByGownId(Guid id)
    {
        IEnumerable<GownBookingResponse> bookings = await repository.GetBookingsByGownId(id);
        if (bookings.Any())
        return APIResponse<IEnumerable<GownBookingResponse>>.SuccessResponse(bookings, APIStatusCodes.OK, "Success");

            return APIResponse<IEnumerable<GownBookingResponse>>.ErrorResponse("No Bookings Available", APIStatusCodes.NotFound);
    }

    public async Task<APIResponse<IEnumerable<StudentGownBookingsResponse>>> GetGownBookings(Guid convocationId)
    {
        var booking = await repository.GetGownBookings(convocationId);
        if (booking is null)
            return APIResponse<IEnumerable<StudentGownBookingsResponse>>.ErrorResponse("No Booking found.", APIStatusCodes.BadRequest);

        return APIResponse<IEnumerable<StudentGownBookingsResponse>>.SuccessResponse(booking, APIStatusCodes.OK, "Success");
    }

    public async Task<APIResponse<StudentBookingGownResponse>> GetMyBookings()
    {
        var userId = contextService.GetUserId();
       var booking =  await repository.GetMyBookings(userId);
        if (booking is null)
            return APIResponse<StudentBookingGownResponse>.ErrorResponse("No Booking found.", APIStatusCodes.BadRequest);

        return APIResponse<StudentBookingGownResponse>.SuccessResponse(booking, APIStatusCodes.OK, "Success");

    }

    public async Task<APIResponse<int>> TotalSalesAmountByGownId(Guid gownId)
    {
       int? total = await repository.TotalSalesAmountByGownId(gownId);
        if (total is null )
            return APIResponse<int>.ErrorResponse("No Sales", APIStatusCodes.BadRequest);

        return APIResponse<int>.SuccessResponse(total.Value, APIStatusCodes.OK, "Success");
    }
}