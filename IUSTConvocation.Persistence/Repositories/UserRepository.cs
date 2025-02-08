#region using
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Persistence;


#endregion

namespace IUSTConvocation.Persistence.Repositories;


public class UserRepository : BaseRepository, IBaseRepository, IUserRepository
{
    public UserRepository(ConvocationDbContext context) : base(context) { }

}

