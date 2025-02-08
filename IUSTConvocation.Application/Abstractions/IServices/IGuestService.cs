using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IGuestService
{
	Task<APIResponse<GuestResponse>> Add(GuestRequest model);


	Task<APIResponse<GuestResponse>> GetById(Guid id);


	Task<APIResponse<IEnumerable<GuestResponse>>> GetAll();


	Task<APIResponse<GuestResponse>> Update(GuestUpdateRequest model);


	Task<APIResponse<GuestResponse>> Delete(Guid id);
}
