using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService service;

    public StudentsController(IStudentService service)
    {
        this.service = service;
    }

    [HttpGet("student-id")]
    public Task<APIResponse<StudentResponse>> GetById([FromQuery] Guid? id)
    {
        return service.GetById(id);
    }

    [HttpPut]
    public Task<APIResponse<StudentResponse>> Update([FromForm] StudentRequest model)
    {
        return service.Update(model);
    }


    [HttpDelete("{id:guid}")]
    public Task<APIResponse<StudentResponse>> Delete(Guid id)
    {
        return service.Delete(id);
    }


    [HttpGet]
    public Task<APIResponse<IEnumerable<StudentResponse>>> GetAll()
    {
        return service.GetAll();
    }
}
