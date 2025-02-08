using AutoMapper;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Services;

public class SeatAllocationService : ISeatAllocationService
{
    private readonly ISeatAllocationRepository repository;
    private readonly IMapper mapper;
    private readonly IContextService contextAccessor;

    public SeatAllocationService(ISeatAllocationRepository repository, IMapper mapper, IContextService contextAccessor)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.contextAccessor = contextAccessor;
    }

    public async Task<APIResponse<SeatAllocationResponse>> Add(SeatAllocationRequest model)
    {
        var seatExist = await repository.FirstOrDefaultAsync<SeatAllocation>(x => x.ConvocationId == model.ConvocationId && x.SeatId == model.SeatId );
        if (seatExist is not null)
            return APIResponse<SeatAllocationResponse>.ErrorResponse("Seat already Occupied", APIStatusCodes.Conflict);


        var memberExist = await repository.FirstOrDefaultAsync<SeatAllocation>(x => x.ConvocationId == model.ConvocationId  && x.EntityId == model.EntityId);
        if (memberExist is not null)
            return APIResponse<SeatAllocationResponse>.ErrorResponse("Already allocated the seat", APIStatusCodes.Conflict);


        var seatAllocation = mapper.Map<SeatAllocation>(model);

        int returnValue = await repository.InsertAsync(seatAllocation);
        return returnValue > 0
            ? APIResponse<SeatAllocationResponse>.SuccessResponse(mapper.Map<SeatAllocationResponse>(seatAllocation), "Seat Allocation added successfully", APIStatusCodes.Created)
            : APIResponse<SeatAllocationResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
    }

    public async Task<APIResponse<SeatAllocationResponse>> Delete(Guid id)
    {
        var seatAllocation = await repository.GetByIdAsync<SeatAllocation>(id);
        if (seatAllocation is not null)
        {
            int returnValue = await repository.DeleteAsync(seatAllocation);

            return returnValue > 0
                ? APIResponse<SeatAllocationResponse>.SuccessResponse(mapper.Map<SeatAllocationResponse>(seatAllocation), "Seat Alocation deleted successfully", APIStatusCodes.OK)
                : APIResponse<SeatAllocationResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }
        return APIResponse<SeatAllocationResponse>.ErrorResponse("No Seat Allocations found", APIStatusCodes.NotFound);
    }

    public async Task<APIResponse<IEnumerable<SeatAllocationResponse>>> GetAllByConvocation(Guid id)
    {
        var seatAllocations = await repository.GetAllByConvocation(id);

        return seatAllocations.Any()
            ? APIResponse<IEnumerable<SeatAllocationResponse>>.SuccessResponse(seatAllocations, $"Found {seatAllocations.Count()} seat allocations", APIStatusCodes.OK)
            : APIResponse<IEnumerable<SeatAllocationResponse>>.ErrorResponse("No Seat Allocations found", APIStatusCodes.NoContent);
    }


    public async Task<APIResponse<IEnumerable<AllocatedSeatsResponse>>> GetAllocatedSeats(Guid id)
    {
        var seatAllocations = await repository.GetAllocatedSeats(id);

        return seatAllocations.Any()
            ? APIResponse<IEnumerable<AllocatedSeatsResponse>>.SuccessResponse(seatAllocations, $"Found {seatAllocations.Count()} seat allocations", APIStatusCodes.OK)
            : APIResponse<IEnumerable<AllocatedSeatsResponse>>.ErrorResponse("No Seat Allocations found", APIStatusCodes.NoContent);
    }


    // not needed
    public async Task<APIResponse<SeatAllocationResponse>> GetById(Guid id)
    {
        var seatAllocation = await repository.GetByIdAsync<SeatAllocation>(id);

        return seatAllocation is not null
            ? APIResponse<SeatAllocationResponse>.SuccessResponse(mapper.Map<SeatAllocationResponse>(seatAllocation), "Successfull", APIStatusCodes.OK)
            : APIResponse<SeatAllocationResponse>.ErrorResponse("No Seat Allocations found", APIStatusCodes.NotFound);
    }

    public async Task<APIResponse<SeatAllocationResponse>> Update(SeatAllocationUpdateRequest model)
    {
        var seatAllocation = await repository.GetByIdAsync<SeatAllocation>(model.Id);

        if (seatAllocation is not null)
        {
            var updatedConvocation = mapper.Map(model, seatAllocation);

            int returnValue = await repository.UpdateAsync(updatedConvocation);
            return returnValue > 0
                ? APIResponse<SeatAllocationResponse>.SuccessResponse(mapper.Map<SeatAllocationResponse>(updatedConvocation), "Seat Allocation updated successfully", APIStatusCodes.OK)
                : APIResponse<SeatAllocationResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }
        return APIResponse<SeatAllocationResponse>.ErrorResponse("No Seat Allocation found", APIStatusCodes.NotFound);
    }


}
