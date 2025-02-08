using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GownBookingController : ControllerBase
{
    private readonly IGownBookingService service;
    public GownBookingController(IGownBookingService service)
    {
        this.service = service;
    }


    [HttpPost("CreateOrder")]
    public async Task<APIResponse<AppOrderResponse>> BookGown(AppOrderRequest model)
    {
        return await service.BookGown(model);
    }


    [HttpPost("CapturePaymentDetails")]
    public async Task<APIResponse<PaymentDetailsResponse>> CapturePaymentDetails(PaymentDetailsRequest model)
    {
        return await service.CapturePaymentDetails(model);
    }


    [HttpGet("bookings-gown/{id:guid}")]
    public async Task<APIResponse<IEnumerable<GownBookingResponse>>> GetBookingsByGownId(Guid id)
    {
        return await service.GetBookingsByGownId(id);
    }



    [HttpGet("mybooking")]
    public async Task<APIResponse<StudentBookingGownResponse>> GetMyBookings()
    {
        return await service.GetMyBookings();
    }


    [HttpGet("gown-bookings/{convocationid:guid}")]
    public async Task<APIResponse<IEnumerable<StudentGownBookingsResponse>>> GetGownBookings(Guid convocationid)
    {
        return await service.GetGownBookings(convocationid);
    }


    [HttpGet("totalsales-gown/{gownId:guid}")]
    public async Task<APIResponse<int>> TotalSalesAmountByGownId(Guid gownId)
    {
        return await service.TotalSalesAmountByGownId(gownId);

    }
}

