using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IConvocationRepository : IBaseRepository
{
    Task<IEnumerable<MemberConvocationResponse>> GetAllMemberConvocations(Guid memberId);

    Task<IEnumerable<ConvocationWithVenueResponse>> GetAllConvocations();

    Task<IEnumerable<ConvocationCompact>> GetAllCompactConvocations();

    Task<IEnumerable<StudentConvocationDetailsResponse>> GetMyConvocations(Guid studentId);
}
