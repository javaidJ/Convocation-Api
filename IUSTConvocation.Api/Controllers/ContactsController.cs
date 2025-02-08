using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Application.Abstractions.Identity;

namespace IUSTConvocation.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService service;

    public ContactsController(IContactService service)
    {
        this.service = service;
    }


    [HttpPost]
    public async Task<APIResponse<ContactResponse>> Post(ContactRequest model) =>await service.Add(model);

    [HttpGet]
    public async Task<APIResponse<IEnumerable<ContactResponse>>> GetAll() => await service.GetAll();


    [HttpGet("{id:guid}")]
    public async Task<APIResponse<ContactResponse>> GetById([FromRoute] Guid id) => await service.GetById(id);



    [HttpDelete("{id:guid}")]
    public async Task<APIResponse<ContactResponse>> Delete([FromRoute] Guid id) => await service.Delete(id);
    
}