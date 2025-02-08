using IUSTConvocation.Application.Abstractions.IRepositories;

namespace IUSTConvocation.Persistence.Repositories;

public class GuestRepository : BaseRepository, IGuestRepository, IBaseRepository
{
	private readonly ConvocationDbContext context;
    public GuestRepository(ConvocationDbContext context) : base(context)
	{
        this.context = context;
    }
}
