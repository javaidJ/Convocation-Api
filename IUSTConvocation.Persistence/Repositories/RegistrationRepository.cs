using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;

namespace IUSTConvocation.Persistence.Repositories;

public class RegistrationRepository : BaseRepository, IRegistrationRepository, IBaseRepository
{

    private readonly ConvocationDbContext context;
    public RegistrationRepository(ConvocationDbContext context) : base(context) => this.context = context;



    private readonly string employeeRegistrationQuery = $@" SELECT U.Id, R.EntityId, R.ConvocationId, R.Module, C.ConvocationDate, DATEDIFF(DAY,GETDATE(), C.ConvocationDate) AS DaysLeft,
		                                                    E.[Name], U.Email, U.ContactNo, U.Gender, R.CreatedOn, R.ParticipantRole
				                                            
                                                            FROM [Registrations] R
				                                            INNER JOIN Convocations C
				                                            ON C.Id =R.ConvocationId
				                                            INNER JOIN Employees E
				                                            ON R.EntityId = E.Id
				                                            INNER JOIN	 Users U
				                                            ON U.Id = E.Id
				                                            WHERE R.ConvocationId =@convocationId";


    private readonly string studentRegistrationQuery = $@" SELECT U.Id, R.EntityId, R.ConvocationId, R.Module, S.[Name], C.ConvocationDate,  DATEDIFF(DAY,GETDATE(), C.ConvocationDate) AS DaysLeft,
                                                        U.Email, U.ContactNo, U.Gender, R.CreatedOn , R.ParticipantRole

						                                FROM [Registrations] R
                                                        INNER JOIN Convocations C
				                                        ON C.Id =R.ConvocationId
                                                        INNER JOIN Students S
                                                        ON R.EntityId = S.Id
										                INNER JOIN	 Users U
										                ON U.Id = S.Id
										                WHERE R.ConvocationId =@convocationId AND R.RegistrationStatus ={(int)RegistrationStatus.Approved} ";


    private readonly string guestRegistrationQuery = $@" SELECT G.Id, R.EntityId, R.ConvocationId, R.Module, G.[Name], G.Email,  C.ConvocationDate,  DATEDIFF(DAY,GETDATE(), C.ConvocationDate) AS DaysLeft,
                                                         G.ContactNo, G.Gender, R.CreatedOn , R.ParticipantRole
						                                
                                                         FROM [Registrations] R
                                                         INNER JOIN Convocations C
				                                         ON C.Id =R.ConvocationId
                                                         INNER JOIN Guests G
                                                         ON R.EntityId = G.Id
										                 WHERE R.ConvocationId =@convocationId";



    public async Task<IEnumerable<RegistrationResponse>?> GetAllRegistrationsByConvocation(Guid id)
    {

        var employeesResponse = await QueryAsync<RegistrationResponse>(employeeRegistrationQuery, new { convocationId = id });
        var studentsResponse = await QueryAsync<RegistrationResponse>(studentRegistrationQuery, new { convocationId = id });
        var guestsResponse = await QueryAsync<RegistrationResponse>(guestRegistrationQuery, new { convocationId = id });

        var registrationResponses = new List<RegistrationResponse>();
       
        if (employeesResponse.Any())
            registrationResponses.AddRange(employeesResponse);

        if (studentsResponse.Any())
            registrationResponses.AddRange(studentsResponse);

        if (guestsResponse.Any())
            registrationResponses.AddRange(guestsResponse);

        return registrationResponses;
    }

    public async Task<RegistrationResponse?> GetConvocationRegistrationByEntityId(Guid convocationid, Guid entityId)
    {
        var responses = await GetAllRegistrationsByConvocation(convocationid);
        return responses!.FirstOrDefault(x => x.EntityId == entityId);
    }

    public async Task<IEnumerable<RegistrationResponse>?> GetAllRegisteredEmployeesByConvocationId(Guid convocationId)
    {
          return await QueryAsync<RegistrationResponse>(employeeRegistrationQuery, new { convocationId });
    }


    public async Task<IEnumerable<RegistrationResponse>?> GetAllRegisteredStudentsByConvocationId(Guid convocationId)
    {
        return await QueryAsync<RegistrationResponse>(studentRegistrationQuery, new { convocationId });
    }


    public async Task<IEnumerable<RegistrationResponse>?> GetAllRegisteredGuestsByConvocationId(Guid convocationId)
    {
        return await QueryAsync<RegistrationResponse>(guestRegistrationQuery, new { convocationId });
    }

    public async Task<IEnumerable<PendingStudentRegistrationResponse>?> GetAllPendingStudentRegistrations(Guid convocationId)
    {
          string studentRegistrationQuery = $@" SELECT R.Id, R.EntityId, R.ConvocationId, R.Module, S.[Name], 
                                                        U.Email, U.ContactNo, U.Gender, R.CreatedOn , 
                                                        R.ParticipantRole,R.RegistrationStatus

						                                FROM [Registrations] R
                                                        INNER JOIN Students S
                                                        ON R.EntityId = S.Id
										                INNER JOIN	 Users U
										                ON U.Id = S.Id
										                WHERE R.ConvocationId =@convocationId ";

        return await QueryAsync<PendingStudentRegistrationResponse>(studentRegistrationQuery, new { convocationId });
    }
}