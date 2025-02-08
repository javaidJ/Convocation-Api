using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpGet("id")]
    public Task<APIResponse<EmployeeResponse>> GetById(Guid? id)
    {
        return _employeeService.GetById(id);
    }


    [HttpDelete("{id:guid}")]
    public Task<APIResponse<EmployeeResponse>> Delete([FromRoute]Guid id)
    {
        return _employeeService.Delete(id);
    }

    [HttpGet]
    public Task<APIResponse<IEnumerable<EmployeeResponse>>> GetAll()
    {
        return _employeeService.GetAll();
    }



    [HttpPut]
    public Task<APIResponse<EmployeeResponse>> Update([FromBody]EmployeeRequest model)
    {
        return _employeeService.Update(model);
    }
}
