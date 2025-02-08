using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IEmployeeRepository : IBaseRepository
{
    Task<IEnumerable<EmployeeResponse>?> GetAllEmployees();

    Task<EmployeeResponse?> GetEmployeeById(Guid id);
}
