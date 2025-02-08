using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IRehersalService
{

    Task<APIResponse<RehersalResponse>> Add(RehersalRequest model);

    Task<APIResponse<RehersalResponse>> GetById(Guid id);

    Task<APIResponse<IEnumerable<RehersalResponse>>> GetAll();

    Task<APIResponse<RehersalResponse>> Update(RehersalUpdateRequest model);

    Task<APIResponse<RehersalResponse>> Delete(Guid id);

}
