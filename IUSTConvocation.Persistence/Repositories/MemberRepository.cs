using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Persistence.Repositories
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        public MemberRepository(ConvocationDbContext context) : base(context) { }

        private readonly string employeeMemberQuery = $@" SELECT M.Id, M.EntityId, M.ConvocationId, M.Module, E.[Name], U.Email, U.ContactNo, U.Gender, M.JobRole , M.CreatedOn  
						                                    FROM [Member] M
                                                            INNER JOIN Employees E
                                                            ON M.EntityId = E.Id
										                    INNER JOIN	 Users U
										                    ON U.Id = E.Id
										                    WHERE M.ConvocationId =@convocationId ";


        private readonly string studentMemberQuery = $@" SELECT M.Id, M.EntityId, M.ConvocationId, M.Module, S.[Name], U.Email, U.ContactNo, U.Gender, M.JobRole ,  M.CreatedOn  
						                                FROM [Member] M
                                                        INNER JOIN Students S
                                                        ON M.EntityId = S.Id
										                INNER JOIN	 Users U
										                ON U.Id = S.Id
										                WHERE M.ConvocationId =@convocationId ";


        private readonly string guestMemberQuery = $@" SELECT M.Id, M.EntityId, M.ConvocationId, M.Module, G.[Name], G.Email, G.ContactNo, G.Gender, M.JobRole ,  M.CreatedOn  
						                                FROM [Member] M
                                                        INNER JOIN Guests G
                                                        ON M.EntityId = G.Id
										                WHERE M.ConvocationId =@convocationId";



        public async Task<IEnumerable<MemberResponse>?> GetAllMembersByConvocation(Guid id)
        {
            
            var employeeMembers=await  QueryAsync<MemberResponse>(employeeMemberQuery, new { convocationId =id});
            var studentMembers=await  QueryAsync<MemberResponse>(studentMemberQuery, new { convocationId =id});
            var guestMembers=await  QueryAsync<MemberResponse>(guestMemberQuery, new { convocationId =id});

            var memberResponses=new List<MemberResponse>();

            if (employeeMembers.Any())
               memberResponses.AddRange(employeeMembers);

            if(studentMembers.Any())
                memberResponses.AddRange(studentMembers);

            if (guestMembers.Any())
             memberResponses.AddRange(guestMembers);


            return memberResponses;
        }

        public async Task<MemberResponse?> GetMemberByConvocationId(Guid convocationid, Guid memberId)
        {
           var responses=   await GetAllMembersByConvocation(convocationid);
           return responses!.FirstOrDefault(x => x.EntityId == memberId);
        }
    }
}
