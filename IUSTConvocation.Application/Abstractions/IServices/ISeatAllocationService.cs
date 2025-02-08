using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface ISeatAllocationService
{
    Task<APIResponse<SeatAllocationResponse>> Add(SeatAllocationRequest model);

    Task<APIResponse<SeatAllocationResponse>> GetById(Guid id);

    Task<APIResponse<IEnumerable<SeatAllocationResponse>>> GetAllByConvocation(Guid id);

    Task<APIResponse<SeatAllocationResponse>> Delete(Guid id);

    Task<APIResponse<SeatAllocationResponse>> Update(SeatAllocationUpdateRequest model);

    Task<APIResponse<IEnumerable<AllocatedSeatsResponse>>> GetAllocatedSeats(Guid id);
}
