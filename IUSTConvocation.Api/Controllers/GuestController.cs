using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class GuestController : ControllerBase
{
	private readonly IGuestService _guestService;

	public GuestController(IGuestService guestService)
	{
		_guestService = guestService;
	}


	[HttpPost]
	public Task<APIResponse<GuestResponse>> Add(GuestRequest model)
	{
		return _guestService.Add(model);
	}


	[HttpDelete("{id:guid}")]
	public Task<APIResponse<GuestResponse>> Delete([FromRoute] Guid id)
	{
		return _guestService.Delete(id);
	}


	[HttpGet]
	public Task<APIResponse<IEnumerable<GuestResponse>>> GetAll()
	{
		return _guestService.GetAll();
	}


	[HttpGet("{id:guid}")]
	public Task<APIResponse<GuestResponse>> GetById([FromRoute] Guid id)
	{
		return _guestService.GetById(id);
	}


	[HttpPut]
	public Task<APIResponse<GuestResponse>> Update([FromBody] GuestUpdateRequest model)
	{
		return _guestService.Update(model);
	}
}
