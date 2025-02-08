using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase, IDepartmentService
{

    private readonly IDepartmentService service;
    public DepartmentsController(IDepartmentService service)
    {
        this.service = service;
    }



    [HttpPost]
    public Task<APIResponse<DepartmentResponse>> Add([FromBody] DepartmentRequest model)
    {
        return service.Add(model);
    }


    [HttpDelete("{id:guid}")]
    public Task<APIResponse<DepartmentResponse>> Delete([FromRoute] Guid id)
    {
        return service.Delete(id);
    }


    [HttpGet]
    public Task<APIResponse<IEnumerable<DepartmentResponse>>> GetAll()
    {
        return service.GetAll();
    }


    [HttpGet("{id:guid}")]
    public Task<APIResponse<DepartmentResponse>> GetById([FromRoute] Guid id)
    {
        return service.GetById(id);
    }


    [HttpPut]
    public Task<APIResponse<DepartmentResponse>> Update([FromBody] DepartmentUpdateRequest model)
    {
        return service.Update(model);
    }
}
