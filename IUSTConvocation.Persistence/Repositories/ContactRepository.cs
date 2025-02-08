using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Persistence;
using IUSTConvocation.Persistence.Repositories;

namespace IUSTConvocation.Persistence.Repositories;

internal class ContactRepository : BaseRepository, IContactRepository
{
    public ContactRepository(ConvocationDbContext context) : base(context)
    {
            
    }
}
