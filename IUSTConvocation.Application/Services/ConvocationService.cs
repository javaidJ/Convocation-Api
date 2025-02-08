using AutoMapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using IUSTConvocation.Application.Abstractions.Identity;

namespace IUSTConvocation.Application.Services;

public class ConvocationService : IConvocationService
{

    private readonly IConvocationRepository repository;
    private readonly IMapper mapper;
    private readonly IContextService contextService;

    public ConvocationService(IConvocationRepository repository, IMapper mapper, IContextService contextService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.contextService = contextService;
    }


    public async Task<APIResponse<ConvocationResponse>> Add(ConvocationRequest model)
    {
        var ConvocationExist=  await repository.FirstOrDefaultAsync<Convocation>(x=>x.Name == model.Name && x.ConvocationDate == model.ConvocationDate);
       
        if(ConvocationExist is not null)
          return APIResponse<ConvocationResponse>.ErrorResponse("Convation already added", APIStatusCodes.Conflict);

        if(model.ConvocationDate <= DateTimeOffset.Now)
            return APIResponse<ConvocationResponse>.ErrorResponse("Convocation must be greater than current date", APIStatusCodes.BadRequest);

            var convocation = mapper.Map<Convocation>(model);

        int returnValue = await repository.InsertAsync(convocation);
        if (returnValue > 0)
        {
            return APIResponse<ConvocationResponse>.SuccessResponse(mapper.Map<ConvocationResponse>(convocation), "Convocation added successfully", APIStatusCodes.Created);
        }
        return APIResponse<ConvocationResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
    }



    public async Task<APIResponse<ConvocationResponse>> Update(ConvocationUpdateRequest model)
    {
        var convocation = await repository.GetByIdAsync<Convocation>(model.Id);

        if (convocation is null)
        {
            return APIResponse<ConvocationResponse>.ErrorResponse("No Convocation found", APIStatusCodes.NotFound);
        }

        if (model.ConvocationDate <= DateTimeOffset.Now)
            return APIResponse<ConvocationResponse>.ErrorResponse("Convocation must be greater than current date", APIStatusCodes.BadRequest);

        var updatedConvocation = mapper.Map(model, convocation);

        int returnValue = await repository.UpdateAsync(updatedConvocation);
        if (returnValue > 0)
        {
            return APIResponse<ConvocationResponse>.SuccessResponse(mapper.Map<ConvocationResponse>(convocation), "Convocation updated successfully", APIStatusCodes.OK);
        }
        return APIResponse<ConvocationResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
    }


    public async Task<APIResponse<ConvocationResponse>> GetById(Guid id)
    {
        var convocaiton = await repository.GetByIdAsync<Convocation>(id);

        if (convocaiton is not null)
        {
            return APIResponse<ConvocationResponse>.SuccessResponse(mapper.Map<ConvocationResponse>(convocaiton), "Successfull", APIStatusCodes.OK);
        }

        return APIResponse<ConvocationResponse>.ErrorResponse("No convocaions found", APIStatusCodes.NotFound);
    }


    public async Task<APIResponse<ConvocationResponse>> Delete(Guid id)
    {

        var convocation = await repository.GetByIdAsync<Convocation>(id);
        if (convocation is null)
        {
            return APIResponse<ConvocationResponse>.ErrorResponse("No Convocation found", APIStatusCodes.NotFound);
        }

        convocation.IsDeleted = true;
        int returnValue = await repository.UpdateAsync(convocation);

        if (returnValue > 0)
        {
            return APIResponse<ConvocationResponse>.SuccessResponse(mapper.Map<ConvocationResponse>(convocation), "Convocaiton deleted successfully", APIStatusCodes.OK);
        }

        return APIResponse<ConvocationResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }


    public async Task<APIResponse<IEnumerable<ConvocationWithVenueResponse>>> GetAll()
    {
        //var convocations = (await repository.GetAllAsync<Convocation>()).OrderByDescending(x=>x.ConvocationDate);     
        var convocations = await repository.GetAllConvocations();

        if (convocations is not null && convocations.Any())
            return APIResponse<IEnumerable<ConvocationWithVenueResponse>>.SuccessResponse(convocations, $"Found {convocations.Count()} Convocations", APIStatusCodes.OK);

        return APIResponse<IEnumerable<ConvocationWithVenueResponse>>.ErrorResponse("No Convocations found", APIStatusCodes.NoContent);
    }


    public async Task<APIResponse<IEnumerable<ConvocationCompact>>> GetAllCompactConvocation()
    {
        var convocations = await repository.GetAllCompactConvocations();

        if (convocations is not null && convocations.Any())
            return APIResponse<IEnumerable<ConvocationCompact>>.SuccessResponse(convocations, $"Found {convocations.Count()} Convocations", APIStatusCodes.OK);

        return APIResponse<IEnumerable<ConvocationCompact>>.ErrorResponse("No Convocations found", APIStatusCodes.NoContent);
    }

    public async Task<APIResponse<IEnumerable<MemberConvocationResponse>>> GetAllMemberConvocations()
    {
        var memberId = contextService.GetUserId();
        var convocations = await repository.GetAllMemberConvocations(memberId);

        if (convocations.Any())
            return APIResponse<IEnumerable<MemberConvocationResponse>>.SuccessResponse(convocations, $"Found {convocations.Count()} Convocations", APIStatusCodes.OK);

        return APIResponse<IEnumerable<MemberConvocationResponse>>.ErrorResponse("No Convocations found", APIStatusCodes.NoContent);

    }

    public async Task<APIResponse<IEnumerable<StudentConvocationDetailsResponse>>> GetMyConvocations()
    {
        var userId = contextService.GetUserId();
        var convocations= await repository.GetMyConvocations(userId);
        if (convocations.Any())
            return APIResponse<IEnumerable<StudentConvocationDetailsResponse>>.SuccessResponse(convocations, $"Found {convocations.Count()} Convocations", APIStatusCodes.OK);

        return APIResponse<IEnumerable<StudentConvocationDetailsResponse>>.ErrorResponse("No Convocations found", APIStatusCodes.NoContent);
    }
}
