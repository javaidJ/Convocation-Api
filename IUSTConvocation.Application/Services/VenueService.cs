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
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository repository;
        private readonly IMapper mapper;

        public VenueService(IVenueRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<APIResponse<VenueResponse>> Add(VenueRequest model)
        {
            var VenueExist = await repository.FirstOrDefaultAsync<Venue>(x => x.Name == model.Name);
            if (VenueExist is not null)
                return APIResponse<VenueResponse>.ErrorResponse("Venue already added", APIStatusCodes.Conflict);

            var venue = mapper.Map<Venue>(model);

            int returnValue = await repository.InsertAsync<Venue>(venue);
            if (returnValue > 0)
            {
                return APIResponse<VenueResponse>.SuccessResponse(mapper.Map<VenueResponse>(venue), "Venue added successfully", APIStatusCodes.Created);

            }

            return APIResponse<VenueResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<IEnumerable<VenueResponse>>> GetAll()
        {
            var venues = await repository.GetAllAsync<Venue>();

            if (venues.Any())
                return APIResponse<IEnumerable<VenueResponse>>.SuccessResponse(mapper.Map<IEnumerable<VenueResponse>>(venues), $"Found {venues.Count()} Venues", APIStatusCodes.OK);

            return APIResponse<IEnumerable<VenueResponse>>.ErrorResponse("No Venue found", APIStatusCodes.NoContent);
        }


        public async Task<APIResponse<VenueResponse>> GetById(Guid id)
        {
            var venue = await repository.GetByIdAsync<Venue>(id);

            if (venue is not null)
            {
                return APIResponse<VenueResponse>.SuccessResponse(mapper.Map<VenueResponse>(venue), "Successfull", APIStatusCodes.OK);
            }

            return APIResponse<VenueResponse>.ErrorResponse("No seat found", APIStatusCodes.NotFound);
        }


        public async Task<APIResponse<VenueResponse>> Update(VenueUpdateRequest model)
        {

            var venue = await repository.GetByIdAsync<Venue>(model.Id);

            if (venue is null) return APIResponse<VenueResponse>.ErrorResponse("No Venue found", APIStatusCodes.NotFound);

            var updateVenue = mapper.Map(model, venue);

            int returnValue = await repository.UpdateAsync(updateVenue);
            if (returnValue > 0)
            {
                return APIResponse<VenueResponse>.SuccessResponse(mapper.Map<VenueResponse>(updateVenue), "Seat updated successfully", APIStatusCodes.OK);
            }
            return APIResponse<VenueResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }
    }
}
