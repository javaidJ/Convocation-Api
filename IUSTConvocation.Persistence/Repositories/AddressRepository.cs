using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Persistence.Repositories;

public class AddressRepository : BaseRepository, IAddressRepository
{
    public AddressRepository(ConvocationDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<AddressResponse>> GetAddressesByEntityId(Guid entityId)
    {
        return await QueryAsync<AddressResponse>("SELECT * FROM Addresses WHERE EntityId=@entityId", new { entityId });
    }
}
