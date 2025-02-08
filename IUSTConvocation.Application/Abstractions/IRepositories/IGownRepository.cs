using IUSTConvocation.Application.RRModels;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IGownRepository : IBaseRepository
{
    Task<IEnumerable<GownResponse>> GetAllGowns();
    Task<GownResponse> GetGownById(Guid id);
}
