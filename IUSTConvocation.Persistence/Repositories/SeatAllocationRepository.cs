using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Persistence.Repositories;

public class SeatAllocationRepository : BaseRepository, ISeatAllocationRepository, IBaseRepository
{
    private readonly ConvocationDbContext context;
    public SeatAllocationRepository(ConvocationDbContext context) : base(context) => this.context = context;

    private readonly string employeeQuery = $@" SELECT SA.Id, SA.EntityId, SA.SeatId, S.SeatSection, S.SeatNumber, S.[Row], E.[Name]
                                                FROM SeatAllocations SA 
                                                INNER JOIN Seats S 
                                                ON SA.SeatId = S.Id
                                                INNER JOIN Employees E
                                                ON E.Id = SA.EntityId
                                                WHERE SA.ConvocationId = @convocationId ";


    private readonly string studentQuery = $@" SELECT SA.Id, SA.EntityId, SA.SeatId, S.SeatSection, S.SeatNumber, S.[Row], St.[Name]
                                                FROM SeatAllocations SA 
                                                INNER JOIN Seats S 
                                                ON SA.SeatId = S.Id
                                                INNER JOIN Students St
                                                ON St.Id = SA.EntityId
                                                WHERE SA.ConvocationId  = @convocationId";



    private readonly string guestQuery = $@" SELECT SA.Id, SA.EntityId, SA.SeatId, S.SeatSection, S.SeatNumber, S.[Row], G.[Name]
                                            FROM SeatAllocations SA 
                                            INNER JOIN Seats S 
                                            ON SA.SeatId = S.Id
                                            INNER JOIN Guests G
                                            ON G.Id = SA.EntityId
                                            WHERE SA.ConvocationId =  @convocationId";


    //private readonly string employeeAllocQuery = $@"	 SELECT SA.Id, SA.ConvocationId, SA.EntityId, SA.SeatId, S.SeatSection, S.SeatNumber, S.[Row], E.[Name],
    //								 U.ContactNo, U.Email , U.Gender, R.ParticipantRole,R.Module
    //                                            FROM SeatAllocations SA 
    //                                            INNER JOIN Seats S 
    //                                            ON SA.SeatId = S.Id
    //                                            INNER JOIN Employees E
    //                                            ON E.Id = SA.EntityId
    //									INNER JOIN Users U
    //								ON U.Id = E.Id
    //								INNER JOIN Registrations R
    //								ON R.EntityId = E.Id
    //                                            WHERE SA.ConvocationId = @convocationId  ";




    private readonly string employeeAllocQuery = $@"	 SELECT SA.Id, SA.ConvocationId, SA.EntityId, SA.SeatId,
                                                    S.SeatSection, S.SeatNumber, S.[Row], E.[Name],U.UserRole,
												 U.ContactNo, U.Email , U.Gender , M.JobRole AS ParticipantRole, M.Module
                                                FROM Employees E
												INNER JOIN Users U
												ON U.Id = E.Id
												INNER JOIN Member M
												ON M.EntityId =  E.Id
												 INNER JOIN SeatAllocations SA 
												 ON SA.EntityId = E.Id
                                                INNER JOIN Seats S 
                                                ON SA.SeatId = S.Id
												INNER JOIN Convocations C 
												ON C.Id = M.ConvocationId
												
                                                WHERE SA.ConvocationId = @convocationId    ";


    //private readonly string studentAllocQuery = $@" SELECT SA.Id, SA.ConvocationId, SA.EntityId, SA.SeatId,
    //                                            S.SeatSection, S.SeatNumber, S.[Row], St.[Name], U.ContactNo,
    //                                            U.Email , U.Gender, R.ParticipantRole,R.Module
    //                                            FROM SeatAllocations SA 
    //                                            INNER JOIN Seats S 
    //                                            ON SA.SeatId = S.Id
    //                                            INNER JOIN Students St
    //                                            ON St.Id = SA.EntityId
    //								INNER JOIN Users U
    //								ON U.Id = St.Id

    //								INNER JOIN Registrations R
    //								ON R.EntityId = St.Id
    //                                            WHERE SA.ConvocationId  = @convocationId ";

    private readonly string studentAllocQuery = $@"  WITH SeatCTE AS
				                                (
					                                SELECT   ROW_NUMBER()  over (partition by   SA.SeatId  order by  SA.SeatId) as RowNum, 
					                                SA.Id, SA.ConvocationId, SA.EntityId, SA.SeatId,
                                                    S.SeatSection, S.SeatNumber, S.[Row], St.[Name], U.ContactNo,
                                                    U.Email , U.Gender, R.ParticipantRole,R.Module
                                                    FROM SeatAllocations SA 
                                                    INNER JOIN Seats S 
                                                    ON SA.SeatId = S.Id
                                                    INNER JOIN Students St
                                                    ON St.Id = SA.EntityId
					                                INNER JOIN Users U
					                                ON U.Id = St.Id
					                                INNER JOIN Registrations R
					                                ON R.EntityId = St.Id
					
			                                )

			                                 SELECT  * FROM SeatCTE WHERE RowNum = 1  AND  ConvocationId  = @convocationId  ";


    private readonly string guestAllocQuery = $@" SELECT SA.Id, SA.ConvocationId, SA.EntityId, SA.SeatId, S.SeatSection,
                                            S.SeatNumber, S.[Row], G.[Name] , G.ContactNo,
                                             G.Email , G.Gender, R.ParticipantRole,R.Module
                                            FROM SeatAllocations SA 
                                            INNER JOIN Seats S 
                                            ON SA.SeatId = S.Id
                                            INNER JOIN Guests G
                                            ON G.Id = SA.EntityId
											INNER JOIN Registrations R
											ON R.EntityId = G.Id
                                            WHERE SA.ConvocationId =  @convocationId";



    public async Task<IEnumerable<SeatAllocationResponse>?> GetAllByConvocation(Guid id)
    {
        var res1 = await QueryAsync<SeatAllocationResponse>(employeeQuery, new { convocationId = id });
        var res2 = await QueryAsync<SeatAllocationResponse>(studentQuery, new { convocationId = id });
        var res3 = await QueryAsync<SeatAllocationResponse>(guestQuery, new { convocationId = id });

        var memberResponses = new List<SeatAllocationResponse>();
        if (res1.Any())
            memberResponses.AddRange(res1);
        if (res2.Any())
            memberResponses.AddRange(res2);
        if (res3.Any())
            memberResponses.AddRange(res3);
        return memberResponses;
    }


    public async Task<IEnumerable<AllocatedSeatsResponse>?> GetAllocatedSeats(Guid id)
    {
        var res1 = await QueryAsync<AllocatedSeatsResponse>(employeeAllocQuery, new { convocationId = id });
        var res2 = await QueryAsync<AllocatedSeatsResponse>(studentAllocQuery, new { convocationId = id });
        var res3 = await QueryAsync<AllocatedSeatsResponse>(guestAllocQuery, new { convocationId = id });

        var memberResponses = new List<AllocatedSeatsResponse>();
        if (res1.Any())
            memberResponses.AddRange(res1);
        if (res2.Any())
            memberResponses.AddRange(res2);
        if (res3.Any())
            memberResponses.AddRange(res3);
        return memberResponses;
    }
}
