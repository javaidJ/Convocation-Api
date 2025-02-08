using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Services;

public class RehersalService : IRehersalService
{

    private readonly IRehersalRepository repository;
    public RehersalService(IRehersalRepository repository)
    {
        this.repository = repository;
    }

    public async Task<APIResponse<RehersalResponse>> Add(RehersalRequest model)
    {

        var IUSTConvocation = await repository.GetByIdAsync<Domain.Entities.Convocation>(model.IUSTConvocationId);

        if (IUSTConvocation is null)
            return APIResponse<RehersalResponse>.ErrorResponse("IUSTConvocation not found", APIStatusCodes.NotFound);


        return default;

    }

    public Task<APIResponse<RehersalResponse>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<APIResponse<IEnumerable<RehersalResponse>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<APIResponse<RehersalResponse>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<APIResponse<RehersalResponse>> Update(RehersalUpdateRequest model)
    {
        throw new NotImplementedException();
    }
}
