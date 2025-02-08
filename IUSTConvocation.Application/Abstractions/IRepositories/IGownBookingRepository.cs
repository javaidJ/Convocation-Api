using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IGownBookingRepository : IBaseRepository
{
    Task<IEnumerable<GownBookingResponse>> GetBookingsByGownId(Guid id);

    Task<GownBookingResponse> GetBookingById(Guid id);

    Task<StudentBookingGownResponse> GetMyBookings(Guid id);

    Task<int> TotalSalesAmountByGownId(Guid gownId);

    Task<IEnumerable<StudentGownBookingsResponse>> GetGownBookings(Guid convocationId);

}
