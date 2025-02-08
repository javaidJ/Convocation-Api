using AutoMapper;
using AutoMapper.Execution;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository repository;
        private readonly IGownBookingRepository gownBookingRepository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public RegistrationService(IRegistrationRepository repository, IGownBookingRepository gownBookingRepository, IMapper mapper, IContextService contextService)
        {
            this.repository = repository;
            this.gownBookingRepository = gownBookingRepository;
            this.mapper = mapper;
            this.contextService = contextService;
        }


        public async Task<APIResponse<RegistrationResponse>> StudentConvocationRegistration(Guid convocationId)
        {
            var userId= contextService.GetUserId();
            //var alreadyBookedGown= await gownBookingRepository.FirstOrDefaultAsync<GownBooking>(x => x.EntityId == userId && x.ConvocationId == convocationId);

            //if(alreadyBookedGown is  null)
            //    return APIResponse<RegistrationResponse>.ErrorResponse("Please Book you gown first", APIStatusCodes.Conflict);

            var registered = await repository.FirstOrDefaultAsync<Registration>(x => x.EntityId == contextService.GetUserId() && x.ConvocationId == convocationId);
            if (registered is not null)
                return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.AlreadyAvailable, APIStatusCodes.Conflict);


            Registration registration = new()
            {
                EntityId = contextService.GetUserId(),
                ConvocationId = convocationId,
                ParticipantRole = Domain.Enums.ParticipantRole.Nominee,
                RegistrationStatus = Domain.Enums.RegistrationStatus.Pending,
                Module = Domain.Enums.Module.Student
            };

            int returnValue = await repository.InsertAsync(registration);
            if (returnValue > 0)
                return APIResponse<RegistrationResponse>.SuccessResponse(mapper.Map<RegistrationResponse>(registration), "You are successfully registered", APIStatusCodes.OK);
            return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<IEnumerable<PendingStudentRegistrationResponse>>> GetAllPendingStudentsRegistration(Guid convocationId)
        {
            var students = await repository.GetAllPendingStudentRegistrations(convocationId);
            if (students is not null && students.Any())
                return APIResponse<IEnumerable<PendingStudentRegistrationResponse>>.SuccessResponse(students, "success", APIStatusCodes.OK);

            return APIResponse<IEnumerable<PendingStudentRegistrationResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<RegistrationResponse>> StudentRegistrationUpdateStatus(StudentRegistrationUpdateStatusRequest model)
        {
            var studentRegistration = await repository.FirstOrDefaultAsync<Registration>(x => x.EntityId == model.StudentId && x.ConvocationId == model.ConvocationId);
            
            if (studentRegistration is  null)
                return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            studentRegistration.RegistrationStatus = model.RegistrationStatus;
            int returnValue = await repository.UpdateAsync(studentRegistration);

            if (returnValue > 0)
                return APIResponse<RegistrationResponse>.SuccessResponse(mapper.Map<RegistrationResponse>(studentRegistration), "You are successfully registered", APIStatusCodes.OK);
           
            return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<RegistrationResponse>> RegisterConvocationByAdmin(RegistrationRequest model)
        {
            var registered = await repository.FirstOrDefaultAsync<Registration>(x => x.EntityId == model.EntityId && x.ConvocationId == model.ConvocationId);
            if (registered is not null)
                return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.AlreadyAvailable, APIStatusCodes.Conflict);

            var registration = mapper.Map<Registration>(model);
            registration.RegistrationStatus = Domain.Enums.RegistrationStatus.Approved;
            int returnValue = await repository.InsertAsync(registration);
            if (returnValue > 0)
                return APIResponse<RegistrationResponse>.SuccessResponse(mapper.Map<RegistrationResponse>(registration), "You are successfully registered", APIStatusCodes.OK);
            return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<RegistrationResponse>> Delete(Guid id)
        {
            var registration = await repository.GetByIdAsync<Registration>(id);
            if (registration is null)
                return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            int returnValue = await repository.DeleteAsync(registration);
            if (returnValue > 0)
                return APIResponse<RegistrationResponse>.SuccessResponse(mapper.Map<RegistrationResponse>(registration), "Registration Deleted Successfully", APIStatusCodes.OK);
            return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegistrationsByConvocation(Guid convocationId)
        {
            var convocation = await repository.GetAllRegistrationsByConvocation(convocationId);
            if (convocation is not null && convocation.Any())
                return APIResponse<IEnumerable<RegistrationResponse>>.SuccessResponse(convocation, "success", APIStatusCodes.OK);

            return APIResponse<IEnumerable<RegistrationResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<RegistrationResponse>> GetConvocationRegistrationByEntityId(Guid convocationid, Guid entityId)
        {
            var registration = await repository.GetConvocationRegistrationByEntityId(convocationid, entityId);

            if (registration is not null)
                return APIResponse<RegistrationResponse>.SuccessResponse(registration, "success", APIStatusCodes.OK);

            return APIResponse<RegistrationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredEmployeesByConvocationId(Guid convocationId)
        {
            var convocation = await repository.GetAllRegisteredEmployeesByConvocationId(convocationId);
            if (convocation is not null && convocation.Any())
                return APIResponse<IEnumerable<RegistrationResponse>>.SuccessResponse(convocation, "success", APIStatusCodes.OK);

            return APIResponse<IEnumerable<RegistrationResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredStudentsByConvocationId(Guid convocationId)
        {
            var convocation = await repository.GetAllRegisteredStudentsByConvocationId(convocationId);
            if (convocation is not null && convocation.Any())
                return APIResponse<IEnumerable<RegistrationResponse>>.SuccessResponse(convocation, "success", APIStatusCodes.OK);

            return APIResponse<IEnumerable<RegistrationResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<IEnumerable<RegistrationResponse>>> GetAllRegisteredGuestsByConvocationId(Guid convocationId)
        {
            var convocation = await repository.GetAllRegisteredGuestsByConvocationId(convocationId);
            if (convocation is not null && convocation.Any())
                return APIResponse<IEnumerable<RegistrationResponse>>.SuccessResponse(convocation, "success", APIStatusCodes.OK);

            return APIResponse<IEnumerable<RegistrationResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }
    }
}
