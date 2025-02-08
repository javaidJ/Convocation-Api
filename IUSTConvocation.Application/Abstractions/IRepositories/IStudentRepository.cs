using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IStudentRepository : IBaseRepository
{
    Task<StudentResponse?> GetStudentById(Guid id);
    Task<IEnumerable<StudentResponse>?> GetAllStudent();
}
