using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;


namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IDepartmentService
{

    Task<APIResponse<DepartmentResponse>> Add(DepartmentRequest model);

    Task<APIResponse<DepartmentResponse>> GetById(Guid id);

    Task<APIResponse<IEnumerable<DepartmentResponse>>> GetAll();

    Task<APIResponse<DepartmentResponse>> Update(DepartmentUpdateRequest model);

    Task<APIResponse<DepartmentResponse>> Delete(Guid id);

}
