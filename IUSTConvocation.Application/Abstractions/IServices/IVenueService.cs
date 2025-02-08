using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IVenueService
{

    Task<APIResponse<VenueResponse>> Add(VenueRequest model);

    Task<APIResponse<IEnumerable<VenueResponse>>> GetAll();

    Task<APIResponse<VenueResponse>> GetById(Guid id);

    Task<APIResponse<VenueResponse>> Update(VenueUpdateRequest model);
}
