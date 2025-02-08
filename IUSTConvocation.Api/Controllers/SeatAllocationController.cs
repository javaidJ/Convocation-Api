using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatAllocationController : ControllerBase
{
    private readonly ISeatAllocationService service;

    public SeatAllocationController(ISeatAllocationService service)
    {
        this.service = service;
    }

    [HttpPost]
    public Task<APIResponse<SeatAllocationResponse>> Add(SeatAllocationRequest model)
    {
        return service.Add(model);
    }

    [HttpDelete("{id:guid}")]
    public Task<APIResponse<SeatAllocationResponse>> Delete([FromRoute] Guid id)
    {
        return service.Delete(id);
    }

    [HttpGet("convocation/{id:guid}")]
    public Task<APIResponse<IEnumerable<SeatAllocationResponse>>> GetAll(Guid id)
    {
        return service.GetAllByConvocation(id);
    }

    [HttpGet("{id:guid}")]
    public Task<APIResponse<SeatAllocationResponse>> GetById([FromRoute] Guid id)
    {
        return service.GetById(id);
    }

    [HttpPut]
    public Task<APIResponse<SeatAllocationResponse>> Update([FromForm] SeatAllocationUpdateRequest model)
    {
        return service.Update(model);
    }

    [HttpGet("convocation-allocated-seats/{id:guid}")]
    public Task<APIResponse<IEnumerable<AllocatedSeatsResponse>>> GetAllocatedSeats(Guid id)
    {
        return service.GetAllocatedSeats(id);
    }
}
