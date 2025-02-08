using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;


namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IEmployeeService
{
    Task<APIResponse<IEnumerable<EmployeeResponse>>> GetAll();


    Task<APIResponse<EmployeeResponse>> GetById(Guid? id);


    Task<APIResponse<EmployeeResponse>> Update(EmployeeRequest model);


    Task<APIResponse<EmployeeResponse>> Delete(Guid id);
}
