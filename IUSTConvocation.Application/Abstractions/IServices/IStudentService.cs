using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IStudentService
{

   // Task<APIResponse<StudentResponse>> Add(StudentRequest model);


    Task<APIResponse<StudentResponse>> GetById(Guid? id);


    Task<APIResponse<IEnumerable<StudentResponse>>> GetAll();


    Task<APIResponse<StudentResponse>> Update(StudentRequest model);


    Task<APIResponse<StudentResponse>> Delete(Guid id);
}
