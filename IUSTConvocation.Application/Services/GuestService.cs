using AutoMapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Services
{
    public class GuestService : IGuestService
	{

		private readonly IGuestRepository repository;
		private readonly IMapper mapper;

		public GuestService(IGuestRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}



		public async Task<APIResponse<GuestResponse>> Add(GuestRequest model)
		{
			var guest = mapper.Map<Guest>(model);

			int returnValue = await repository.InsertAsync(guest);

			return returnValue switch
			{
				> 0 => APIResponse<GuestResponse>.SuccessResponse(mapper.Map<GuestResponse>(guest), "Guest saved successfully.", APIStatusCodes.Created),
				_ => APIResponse<GuestResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError)
			};
		}


		public async Task<APIResponse<GuestResponse>> Delete(Guid id)
		{
			var guest = await repository.GetByIdAsync<Guest>(id);

			if (guest is null)
			{
				return APIResponse<GuestResponse>.ErrorResponse("No guest found", APIStatusCodes.NotFound);
			}

			int returnValue = await repository.DeleteAsync(guest);

			return returnValue switch
			{
				> 0 => APIResponse<GuestResponse>.SuccessResponse(mapper.Map<GuestResponse>(guest), "Guest deleted successfully", APIStatusCodes.OK),
				_ => APIResponse<GuestResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError)
			};
		}

		public async Task<APIResponse<IEnumerable<GuestResponse>>> GetAll()
		{
			var guests = await repository.GetAllAsync<Guest>();

			return !guests.Any()
				? APIResponse<IEnumerable<GuestResponse>>.ErrorResponse("No guests found", APIStatusCodes.NoContent)
				: APIResponse<IEnumerable<GuestResponse>>.SuccessResponse(mapper.Map<IEnumerable<GuestResponse>>(guests), $"Found {guests.Count()} guests", APIStatusCodes.OK);
		}


		public async Task<APIResponse<GuestResponse>> GetById(Guid id)
		{
			var guest = await repository.GetByIdAsync<Guest>(id);

			return guest switch
			{
				not null => APIResponse<GuestResponse>.SuccessResponse(mapper.Map<GuestResponse>(guest), "Guest found", APIStatusCodes.OK),
				_ => APIResponse<GuestResponse>.ErrorResponse("No employee found", APIStatusCodes.NotFound)
			};
		}

		public async Task<APIResponse<GuestResponse>> Update(GuestUpdateRequest model)
		{
			var guest = await repository.GetByIdAsync<Guest>(model.Id);

			if (guest is null) return APIResponse<GuestResponse>.ErrorResponse("No Employee found", APIStatusCodes.NotFound);

			var updateGuest = mapper.Map(model, guest);

			int returnValue = await repository.UpdateAsync(updateGuest);

			return returnValue switch
			{
				> 0 => APIResponse<GuestResponse>.SuccessResponse(mapper.Map<GuestResponse>(guest), "Guest updated successfully", APIStatusCodes.OK),
				_ => APIResponse<GuestResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError)
			};
		}
	}
}
