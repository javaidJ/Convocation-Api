using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IMemberRepository : IBaseRepository
{
    Task<IEnumerable<MemberResponse>?> GetAllMembersByConvocation(Guid id);

    Task<MemberResponse?> GetMemberByConvocationId(Guid convocationid, Guid memberId);
}
