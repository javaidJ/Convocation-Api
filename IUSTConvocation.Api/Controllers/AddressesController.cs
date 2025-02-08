using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{

    private readonly IAddressService service;
    public AddressesController(IAddressService service)
    {
        this.service = service;
    }



    [HttpPost]
    public async Task<APIResponse<AddressResponse>> Add(AddressRequest model) => await service.Add(model);


    [HttpGet("entityid")]
    public Task<APIResponse<IEnumerable<AddressResponse>>> GetByEntityId([FromQuery] Guid? entityid) => service.GetByEntityId(entityid);



    [HttpGet("{id:guid}")]
    public async Task<APIResponse<AddressResponse>> GetById([FromRoute] Guid id) => await service.GetById(id);


    [HttpPut]
    public async Task<APIResponse<AddressResponse>> Update(AddressUpdateRequest model) => await service.Update(model);


    [HttpDelete()]
    public async Task<APIResponse<AddressResponse>> Delete([FromQuery] Guid? id) => await service.Delete(id);
   }
