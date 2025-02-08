using System.Net.Http.Headers;
using AutoMapper;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository repository;
    private readonly IMapper mapper;
    private readonly IContextService contextService;

    public AddressService(IAddressRepository repository, IMapper mapper, IContextService contextService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.contextService = contextService;
    }

    public async Task<APIResponse<AddressResponse>> Add(AddressRequest model)
    {
        var address = mapper.Map<Address>(model);
        address.EntityId = model.EntityId ?? contextService.GetUserId();
        address.CreatedBy = address.EntityId;
        address.Module = model.Module;

            var add = await repository.FirstOrDefaultAsync<Address>(x => x.EntityId ==  address.EntityId);
            if (add is not null)
                return APIResponse<AddressResponse>.ErrorResponse("Address already added", APIStatusCodes.InternalServerError);

        int returnValue = await repository.InsertAsync<Address>(address);
        if (returnValue > 0)
        {
            var response = mapper.Map<AddressResponse>(address);
            response.AddressId = address.Id;
            return APIResponse<AddressResponse>.SuccessResponse(response, "Address saved successfully.", APIStatusCodes.Created);
        }

        return APIResponse<AddressResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }

    public async Task<APIResponse<IEnumerable<AddressResponse>>> GetByEntityId(Guid? id)
    {
        var enitityId = id ?? contextService.GetUserId();
        var addresses = await repository.FindByAsync<Address>(address => address.EntityId == enitityId);


        if (addresses.Any())
            return APIResponse<IEnumerable<AddressResponse>>.SuccessResponse(mapper.Map<IEnumerable<AddressResponse>>(addresses), $"Found {addresses.Count()} addresses", APIStatusCodes.OK);

        return APIResponse<IEnumerable<AddressResponse>>.ErrorResponse("No addresses found", APIStatusCodes.NoContent);
    }


    public async Task<APIResponse<AddressResponse>> GetById(Guid id)
    {

        var address = await repository.GetByIdAsync<Address>(id);

        if (address is not null)
            return APIResponse<AddressResponse>.SuccessResponse(mapper.Map<AddressResponse>(address), "Address found", APIStatusCodes.OK);

        return APIResponse<AddressResponse>.ErrorResponse("No Address found", APIStatusCodes.NotFound);

    }



    public async Task<APIResponse<AddressResponse>> Update(AddressUpdateRequest model)
    {
        var dbAddress= await repository.GetByIdAsync<Address>(model.Id);
        
        var address = mapper.Map(model,dbAddress);
        address.EntityId = model.EntityId ?? contextService.GetUserId();

        int returnValue = await repository.UpdateAsync<Address>(address);
        if (returnValue > 0)
            return APIResponse<AddressResponse>.SuccessResponse(mapper.Map<AddressResponse>(address), "Address updated succesfully.", APIStatusCodes.Created);

        return APIResponse<AddressResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }



    public async Task<APIResponse<AddressResponse>> Delete(Guid? id)
    {
        // some delete logic pending when address will be associated with other entities
        var address = await repository.GetByIdAsync<Address>(id ?? contextService.GetUserId());


        if (address is null)
            return APIResponse<AddressResponse>.ErrorResponse("No address found", APIStatusCodes.NotFound);

        int returnValue = await repository.DeleteAsync<Address>(address);


        if (returnValue > 0)
            return APIResponse<AddressResponse>.SuccessResponse(mapper.Map<AddressResponse>(address), "Address deleted successfully", APIStatusCodes.OK);

        return APIResponse<AddressResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }
}
