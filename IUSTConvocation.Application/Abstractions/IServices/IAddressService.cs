using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IAddressService
{

    Task<APIResponse<AddressResponse>> Add(AddressRequest model);



    Task<APIResponse<AddressResponse>> GetById(Guid id);
    


    Task<APIResponse<IEnumerable<AddressResponse>>> GetByEntityId(Guid? id);


    Task<APIResponse<AddressResponse>> Update(AddressUpdateRequest model);


    Task<APIResponse<AddressResponse>> Delete(Guid? id);

}
