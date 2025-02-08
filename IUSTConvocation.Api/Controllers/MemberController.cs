using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Services;
using IUSTConvocation.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberService service;

    public MemberController(IMemberService service)
    {
        this.service = service;
    }

    [HttpPost]
    public Task<APIResponse<MemberResponse>> Add(MemberRequest model)
    {
        return service.Add(model);
    }

    [HttpDelete]
    public Task<APIResponse<MemberResponse>> Delete(Guid id)
    {
        return service.Delete(id);
    }
    [HttpGet("convocation/{id:guid}")]
    public Task<APIResponse<IEnumerable<MemberResponse>>> GetAllByConvocation([FromRoute]Guid id)
    {
        return service.GetAllByConvocation(id);
    }

    [HttpGet("convocation/{convocationId:guid}/member/{id:guid}/")]
    public Task<APIResponse<MemberResponse>> MemberByConvocationId(Guid convocationId, Guid id)
    {
        return service.GetMemberByConvocationId(convocationId,id);
    }

    [HttpPut]
    public Task<APIResponse<MemberResponse>> Update(MemberUpdate model)
    {
        return service.Update(model);
    }
}
