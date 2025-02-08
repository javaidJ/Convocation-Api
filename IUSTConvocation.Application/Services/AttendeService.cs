using AutoMapper;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Services
{
    public class AttendeService : IAttendeService
    {
        private readonly IAttendeRepository repository;
        private readonly IMapper mapper;
        private readonly IContextService contextAccessor;

        public AttendeService(IAttendeRepository repository, IMapper mapper, IContextService contextAccessor)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.contextAccessor = contextAccessor;
        }
        public async Task<APIResponse<AttendeResponse>> Add(AttendeRequest model)
        {
         //   var attende = mapper.Map<OtherAttendee>(model);

            //int returnValue = await repository.InsertAsync(attende);
            //if (returnValue > 0)
            //    return APIResponse<AttendeResponse>.SuccessResponse(mapper.Map<AttendeResponse>(attende), "Attende saved successfully.", APIStatusCodes.Created);

           return APIResponse<AttendeResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<AttendeResponse>> Delete(Guid id)
        {
          //  var attende = await repository.GetByIdAsync<OtherAttendee>(id);
            //if (attende is null)
            //{
            //    return APIResponse<AttendeResponse>.ErrorResponse("No Attende found", APIStatusCodes.NotFound);
            //}

            //int returnValue = await repository.DeleteAsync(attende);

            //if (returnValue > 0)
            //{
            //    return APIResponse<AttendeResponse>.SuccessResponse(mapper.Map<AttendeResponse>(attende), "Attende deleted successfully", APIStatusCodes.OK);
            //}

            return APIResponse<AttendeResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }

        public Task<APIResponse<IEnumerable<AttendeResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<AttendeResponse>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<AttendeResponse>> Update(AttendeUpdateRequest model)
        {
            //var attende = await repository.GetByIdAsync<OtherAttendee>(model.Id);

            //if (attende is null)
            //{
            //    return APIResponse<AttendeResponse>.ErrorResponse("No attende found", APIStatusCodes.NotFound);
            //}

            //var updatedAttende = mapper.Map(model, attende);

            //int returnValue = await repository.UpdateAsync(updatedAttende);
            //if (returnValue > 0)
            //{
            //    return APIResponse<AttendeResponse>.SuccessResponse(mapper.Map<AttendeResponse>(attende), "Attende updated successfully", APIStatusCodes.OK);
            //}

            return APIResponse<AttendeResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }
    }
}
