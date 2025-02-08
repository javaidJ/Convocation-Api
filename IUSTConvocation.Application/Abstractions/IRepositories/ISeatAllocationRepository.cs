using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface ISeatAllocationRepository : IBaseRepository
{
    Task<IEnumerable<SeatAllocationResponse>?> GetAllByConvocation(Guid id);

    Task<IEnumerable<AllocatedSeatsResponse>?> GetAllocatedSeats(Guid id);
}
