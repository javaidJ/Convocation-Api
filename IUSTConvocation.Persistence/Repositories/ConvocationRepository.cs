using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Persistence.Repositories;

public class ConvocationRepository : BaseRepository, IConvocationRepository, IBaseRepository
{

    private readonly ConvocationDbContext context;
    public ConvocationRepository(ConvocationDbContext context) : base(context) => this.context = context;

    public async Task<IEnumerable<MemberConvocationResponse>> GetAllMemberConvocations(Guid memberId)
    {
        string query = $@"SELECT C.Id, C.[Name], C.ConvocationDate, C.[End], C.[Description], C.VenueId,
			                M.EntityId AS MemberId, M.JobRole  , V.[Name] AS Venue, V.TotalSeats
			                FROM Convocations C
			                INNER JOIN [Member] M
			                ON C.Id =M.ConvocationId
			                INNER JOIN Venues V
                            ON C.VenueId = V.Id
			                WHERE C.IsDeleted=0 AND M.EntityId =@memberId
                               ORDER BY C.ConvocationDate DESC ";

        return await QueryAsync<MemberConvocationResponse>(query, new { memberId });
    }

    public async Task<IEnumerable<ConvocationWithVenueResponse>> GetAllConvocations()
    {
        string query = $@" SELECT C.Id, C.[Name], C.ConvocationDate, C.[End], C.[Description],
                              C.VenueId, V.[Name] AS Venue, V.TotalSeats
                              FROM Convocations C
                              INNER JOIN Venues V
                              ON C.VenueId = V.Id
                               WHERE C.IsDeleted= 0
                               ORDER BY C.ConvocationDate DESC ";

        return await QueryAsync<ConvocationWithVenueResponse>(query,null);
    }



    public async Task<IEnumerable<ConvocationCompact>> GetAllCompactConvocations()
    {
        string query = $@" 		WITH ConvocationCTE AS
                                (
                                          SELECT  ROW_NUMBER()  over (partition by   C.Id  order by  C.Createdon) as RowNum, 
		                                       
                                                C.Id , C.[Name], C.ConvocationDate, C.[End], C.[Description], 
												  C.VenueId, V.[Name] AS Venue, V.TotalSeats,
												 (SELECT  COUNT([Member].ConvocationId) FROM [Member] WHERE [Member].ConvocationId=C.Id)  AS TotalMembers,

												  (SELECT  COUNT([Registrations].ConvocationId) FROM [Registrations] WHERE [Registrations].ConvocationId=C.Id AND [Registrations].ParticipantRole = 9)  AS TotalGuests,
												  (SELECT  COUNT([Registrations].ConvocationId) FROM [Registrations] WHERE [Registrations].ConvocationId=C.Id AND [Registrations].ParticipantRole = 11)  AS TotalStudents,
												  (SELECT  COUNT([Registrations].ConvocationId) FROM [Registrations] WHERE [Registrations].ConvocationId=C.Id AND ([Registrations].ParticipantRole != 11 AND [Registrations].ParticipantRole != 9))  AS TotalParticipants

												 
												 FROM Convocations C
												  INNER JOIN Venues V
												  ON C.VenueId = V.Id
												  LEFT JOIN  Registrations R
												  ON R.ConvocationId =C.Id
												  LEFT JOIN [Member] M
												  ON M.ConvocationId = C.Id
												 WHERE C.IsDeleted= 0  
												
					)                                      
			                                SELECT  * FROM ConvocationCTE	WHERE RowNum = 1   ORDER BY ConvocationDate DESC  ";

        return await QueryAsync<ConvocationCompact>(query, null);
    }

    public async Task<IEnumerable<StudentConvocationDetailsResponse>> GetMyConvocations(Guid studentId)
    {
        string query = $@" SELECT C.Id, C.[Name], C.ConvocationDate, C.[End], C.[Description],
                              C.VenueId, V.[Name] AS Venue, V.TotalSeats, S.SeatSection, S.[Row], S.SeatNumber,
                              DATEDIFF(DAY, GETDATE(), C.ConvocationDate ) AS DaysLeft
                              FROM Convocations C
							  LEFT JOIN Registrations R
							  ON C.Id = R.ConvocationId
                              INNER JOIN Venues V
                              ON C.VenueId = V.Id
							  LEFT JOIN SeatAllocations SA
							  ON SA.EntityId = R.EntityId
							  LEFT JOIN Seats S
							  ON S.Id = SA.SeatId
                              WHERE C.IsDeleted= 0 AND R.EntityId=@studentId
                              ORDER BY C.ConvocationDate DESC ";

        return await QueryAsync<StudentConvocationDetailsResponse>(query, new { studentId });
    }
}
