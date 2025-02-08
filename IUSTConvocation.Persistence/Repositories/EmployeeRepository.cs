using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(ConvocationDbContext context) : base(context)  { }


        private readonly string baseQuery = $@" SELECT E.Id, E.EmpCode, E.[Name],U.Email, U.ContactNo, U.Gender,
                                        E.DepartemntId, E.Designation, E.CreatedOn, F.FilePath, D.DepartmentName, 
                                        E.IsDeleted  
						                FROM Users U
                                        INNER JOIN Employees E
                                        ON U.Id = E.Id
                                        LEFT JOIN AppFiles F
                                        ON E.Id = F.EntityId
                                        LEFT JOIN Departments D
                                        ON D.Id = E.DepartemntId WHERE E.IsDeleted =0  ";


        public async Task<IEnumerable<EmployeeResponse>?> GetAllEmployees()
        {
            return await QueryAsync<EmployeeResponse>(baseQuery, null);
        }

        public async Task<EmployeeResponse?> GetEmployeeById(Guid id)
        {
            return await FirstOrDefaultAsync<EmployeeResponse>(baseQuery + " AND  E.Id=@id", new { id });
        }
    }
}
