using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IRegistrationRepository : IBaseRepository
{
    Task<IEnumerable<RegistrationResponse>?> GetAllRegistrationsByConvocation(Guid id);

    Task<IEnumerable<PendingStudentRegistrationResponse>?> GetAllPendingStudentRegistrations(Guid convocationId);

    Task<IEnumerable<RegistrationResponse>?> GetAllRegisteredEmployeesByConvocationId(Guid convocationId);

    Task<IEnumerable<RegistrationResponse>?> GetAllRegisteredStudentsByConvocationId(Guid convocationId);

    Task<IEnumerable<RegistrationResponse>?> GetAllRegisteredGuestsByConvocationId(Guid convocationId);

    Task<RegistrationResponse?> GetConvocationRegistrationByEntityId(Guid convocationid, Guid entityId);
}
