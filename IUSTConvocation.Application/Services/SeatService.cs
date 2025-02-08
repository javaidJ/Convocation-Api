using AutoMapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository repository;
        private readonly IMapper mapper;

        public SeatService(ISeatRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<APIResponse<SeatResponse>> Add(SeatRequest model)
        {

            var seatExist= await repository.FirstOrDefaultAsync<Seat>(x => x.SeatSection == model.SeatSection && x.SeatNumber == model.SeatNumber && x.Row == model.Row && x.VenueId == model.VenueId);
            if(seatExist is not null)
                return APIResponse<SeatResponse>.ErrorResponse("Seat already added", APIStatusCodes.Conflict);

            var seat = mapper.Map<Seat>(model);

            int returnValue = await repository.InsertAsync<Seat>(seat);
            if (returnValue > 0)
            {
                return APIResponse<SeatResponse>.SuccessResponse(mapper.Map<SeatResponse>(seat), "Seat added successfully", APIStatusCodes.Created);

            }

            return APIResponse<SeatResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<IEnumerable<SeatResponse>>> GetAllSeatsByVenue(Guid id)
        {

            var seats = await repository.FindByAsync<Seat>(x=>x.VenueId==id);

            if (seats.Any())
                return APIResponse<IEnumerable<SeatResponse>>.SuccessResponse(mapper.Map<IEnumerable<SeatResponse>>(seats), $"Found {seats.Count()} seats", APIStatusCodes.OK);

            return APIResponse<IEnumerable<SeatResponse>>.ErrorResponse("No Seats found", APIStatusCodes.NoContent);

        }

        public async Task<APIResponse<SeatResponse>> GetById(Guid id)
        {

            var seat = await repository.GetByIdAsync<Seat>(id);

            if (seat is not null)
            {
                return APIResponse<SeatResponse>.SuccessResponse(mapper.Map<SeatResponse>(seat), "Successfull", APIStatusCodes.OK);
            }

            return APIResponse<SeatResponse>.ErrorResponse("No seat found", APIStatusCodes.NotFound);

        }

        public async Task<APIResponse<SeatResponse>> Update(SeatUpdateRequest model)
        {

            var seat = await repository.GetByIdAsync<Seat>(model.Id);

            if (seat is null) return APIResponse<SeatResponse>.ErrorResponse("No seat found", APIStatusCodes.NotFound);

            var updateSeat = mapper.Map(model, seat);

            int returnValue = await repository.UpdateAsync(updateSeat);
            if (returnValue > 0)
            {
                return APIResponse<SeatResponse>.SuccessResponse(mapper.Map<SeatResponse>(seat), "Seat updated successfully", APIStatusCodes.OK);
            }

            return APIResponse<SeatResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<SeatResponse>> Delete(Guid id)
        {

            var seat = await repository.GetByIdAsync<Seat>(id);
            if (seat is null)
            {
                return APIResponse<SeatResponse>.ErrorResponse("No seat found", APIStatusCodes.NotFound);
            }

            int returnValue = await repository.DeleteAsync(seat);

            if (returnValue > 0)
            {
                return APIResponse<SeatResponse>.SuccessResponse(mapper.Map<SeatResponse>(seat), "Seat deleted successfully", APIStatusCodes.OK);
            }

            return APIResponse<SeatResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }

    }
}
