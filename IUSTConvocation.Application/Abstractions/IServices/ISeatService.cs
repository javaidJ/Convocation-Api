using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface ISeatService
{

    Task<APIResponse<SeatResponse>> Add(SeatRequest model);

    Task<APIResponse<IEnumerable<SeatResponse>>> GetAllSeatsByVenue(Guid id);

    Task<APIResponse<SeatResponse>> GetById(Guid id);

    Task<APIResponse<SeatResponse>> Update(SeatUpdateRequest model);

    Task<APIResponse<SeatResponse>> Delete(Guid id);

}
