using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Persistence.Repositories;

public class StudentRepository : BaseRepository, IStudentRepository, IBaseRepository
{

    private readonly ConvocationDbContext context;
    public StudentRepository(ConvocationDbContext context) : base(context)
    {
        this.context = context;
    }
    private readonly string query = $@" SELECT S.Id, S.RegNumber, S.[Name],U.Email, U.ContactNo, U.Gender,S.Parentage,
                        S.DepartemntId, S.Course, S.Batch, S.[Parentage], S.Position,F.FilePath, D.DepartmentName, S.IsDeleted ,s.Percentage 
                        FROM Users U
                        INNER JOIN Students S
                        ON U.Id = S.Id
                        LEFT JOIN AppFiles F
                        ON S.Id = F.EntityId
                        LEFT JOIN Departments D
                        ON D.Id = S.DepartemntId WHERE S.IsDeleted =0  ";


    public async Task<IEnumerable<StudentResponse>?> GetAllStudent()
    {
        return await QueryAsync<StudentResponse>(query,null);
    }

    public async Task<StudentResponse?> GetStudentById(Guid id)
    {
       
       return await FirstOrDefaultAsync<StudentResponse>(query + " AND  S.Id=@id", new { id });
    }


}
