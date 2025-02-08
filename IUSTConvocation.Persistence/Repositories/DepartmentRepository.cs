using IUSTConvocation.Application.Abstractions.IRepositories;

namespace IUSTConvocation.Persistence.Repositories;

public class DepartmentRepository : BaseRepository, IDepartmentRepository, IBaseRepository
{

    private readonly ConvocationDbContext context;
    public DepartmentRepository(ConvocationDbContext context) : base(context)
    {
        this.context = context;
    }



}
