using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConvocationController : ControllerBase
{

    private readonly IConvocationService service;
    public ConvocationController(IConvocationService service)
    {
        this.service = service;
    }


    [HttpPost]
    public Task<APIResponse<ConvocationResponse>> Add([FromBody] ConvocationRequest model)
    {
        return service.Add(model);
    }


    [HttpDelete("{id:guid}")]
    public Task<APIResponse<ConvocationResponse>> Delete([FromRoute] Guid id)
    {
        return service.Delete(id);
    }


    [HttpGet]
    public Task<APIResponse<IEnumerable<ConvocationWithVenueResponse>>> GetAll()
    {
        return service.GetAll();
    }


    [HttpGet("my-convocation")]
    public Task<APIResponse<IEnumerable<StudentConvocationDetailsResponse>>> GetMyConvocations()
    {
        return service.GetMyConvocations();
    }


    [HttpGet("compact-convocation")]
    public Task<APIResponse<IEnumerable<ConvocationCompact>>> GetAllCompactConvocations()
    {
        return service.GetAllCompactConvocation();
    }



    [HttpGet("member-convocations")]
    public Task<APIResponse<IEnumerable<MemberConvocationResponse>>> GetAllMemberConvocations()
    {
        return service.GetAllMemberConvocations();
    }


    [HttpGet("{id:guid}")]
    public Task<APIResponse<ConvocationResponse>> GetById([FromRoute] Guid id)
    {
        return service.GetById(id);
    }


    [HttpPut]
    public Task<APIResponse<ConvocationResponse>> Update([FromBody] ConvocationUpdateRequest model)
    {
        return service.Update(model);
    }
}
