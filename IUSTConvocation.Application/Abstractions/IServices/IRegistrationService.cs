using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IRegistrationService
{

    Task<APIResponse<RegistrationResponse>> StudentConvocationRegistration(Guid convocationId);

    Task<APIResponse<RegistrationResponse>> RegisterConvocationByAdmin(RegistrationRequest model);

    Task<APIResponse<IEnumerable<PendingStudentRegistrationResponse>>> GetAllPendingStudentsRegistration(Guid convocationId);

    Task<APIResponse<RegistrationResponse>> StudentRegistrationUpdateStatus(StudentRegistrationUpdateStatusRequest model);

    Task<APIResponse<RegistrationResponse>> GetConvocationRegistrationByEntityId(Guid convocationid, Guid entityId);


    Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegistrationsByConvocation(Guid convocationId);

    Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredEmployeesByConvocationId(Guid convocationId);

    Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredStudentsByConvocationId(Guid convocationId);

    Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredGuestsByConvocationId(Guid convocationId);

    Task<APIResponse<RegistrationResponse>> Delete(Guid id);
}
