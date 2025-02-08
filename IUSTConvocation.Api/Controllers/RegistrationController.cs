using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase 
{

    private readonly IRegistrationService service;
    public RegistrationController(IRegistrationService service)
    {
        this.service = service;
    }

    // Student convocation Registration by student it self and then needs to be approved by organizer or admin
    [HttpPost("student/{convocationid:guid}")]
    public async Task<APIResponse<RegistrationResponse>> StudentConvocationRegistration(Guid convocationid)
    {
        return await service.StudentConvocationRegistration(convocationid);
    }


    [HttpGet("all-pending-student-registrations/{convocationid:guid}")]
    public async Task<APIResponse<IEnumerable<PendingStudentRegistrationResponse>>> GetAllPendingStudentRegistrations(Guid convocationid)
    {
        return await service.GetAllPendingStudentsRegistration(convocationid);
    }



    [HttpPost("student-update-status")]
    public async Task<APIResponse<RegistrationResponse>> StudentConvocationUpdateStatus(StudentRegistrationUpdateStatusRequest model)
    {
        return await service.StudentRegistrationUpdateStatus(model);
    }


    // Employee(not as a member) and Guest  Registration for convocation by Admin OR Organiser 
    [HttpPost("by-admin-or-organizer")]
    public async Task<APIResponse<RegistrationResponse>> RegisterConvocationByAdmin(RegistrationRequest model)
    {
        return await service.RegisterConvocationByAdmin(model);
    }



    [HttpGet("all-registered-employees/{convocationid:guid}")]
    public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredEmployees(Guid convocationid)
    {
        return await service.GetAllRegisteredEmployeesByConvocationId(convocationid);
    }


    [HttpGet("all-registered-students/{convocationid:guid}")]
    public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredStudents(Guid convocationid)
    {
        return await service.GetAllRegisteredStudentsByConvocationId(convocationid);
    }


    [HttpGet("all-registered-guests/{convocationid:guid}")]
    public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredGuests(Guid convocationid)
    {
        return await service.GetAllRegisteredGuestsByConvocationId(convocationid);
    }


    [HttpGet("all-registration/{id:guid}")]
    public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegistrationsByConvocation(Guid id)
    {
        return await service.GetAllRegistrationsByConvocation(id);
    }



    [HttpGet("{convocationId:guid}/entityid/{id:guid}/")]
    public async Task<APIResponse<RegistrationResponse>> RegistrationByConvocationId(Guid convocationId, Guid id)
    {
        return await service.GetConvocationRegistrationByEntityId(convocationId, id);
    }


    [HttpDelete]
    public async Task<APIResponse<RegistrationResponse>> Delete(Guid id)
    {
        return await service.Delete(id);
    }


    [HttpGet]
    public async Task<APIResponse<RegistrationResponse>> GetConvocationRegistrationByEntityId(Guid convocationid, Guid entityId)
    {
        return await service.GetConvocationRegistrationByEntityId(convocationid, entityId);
    }
}
