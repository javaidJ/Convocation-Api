using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;


namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IMemberService
{
    Task<APIResponse<MemberResponse>> Add(MemberRequest model);

    Task<APIResponse<IEnumerable<MemberResponse>>> GetAllByConvocation(Guid Id);

    Task<APIResponse<MemberResponse>> GetMemberByConvocationId(Guid convocationid, Guid memberId);

    Task<APIResponse<MemberResponse>> Update(MemberUpdate model);

    Task<APIResponse<MemberResponse>> Delete(Guid id);
}
