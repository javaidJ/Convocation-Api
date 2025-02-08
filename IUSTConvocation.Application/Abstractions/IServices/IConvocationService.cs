using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IConvocationService
{

    Task<APIResponse<ConvocationResponse>> Add(ConvocationRequest model);

    Task<APIResponse<ConvocationResponse>> GetById(Guid id);

    Task<APIResponse<IEnumerable<ConvocationWithVenueResponse>>> GetAll();

    Task<APIResponse<IEnumerable<MemberConvocationResponse>>> GetAllMemberConvocations();

    Task<APIResponse<ConvocationResponse>> Delete(Guid id);

    Task<APIResponse<ConvocationResponse>> Update(ConvocationUpdateRequest model);

    Task<APIResponse<IEnumerable<ConvocationCompact>>> GetAllCompactConvocation();

    Task<APIResponse<IEnumerable<StudentConvocationDetailsResponse>>> GetMyConvocations();

}
