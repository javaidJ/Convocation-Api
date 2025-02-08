using AutoMapper;
using AutoMapper.Execution;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public MemberService(IMemberRepository repository,IUserRepository userRepository, IMapper mapper, IContextService contextService)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.contextService = contextService;
        }
        public async Task<APIResponse<MemberResponse>> Add(MemberRequest model)
        {
            var memberExist= await repository.FirstOrDefaultAsync<Domain.Entities.Member>(x => x.EntityId == model.EntityId && x.ConvocationId == model.ConvocationId);
            if (memberExist is not null)
                return APIResponse<MemberResponse>.ErrorResponse("Member already registered", APIStatusCodes.Conflict);

            var member= mapper.Map<Domain.Entities.Member>(model);
            var returnValue= await repository.InsertAsync(member);
            if (returnValue > 0)
                return APIResponse<MemberResponse>.SuccessResponse(mapper.Map<MemberResponse>(member), "Member Added successfully", APIStatusCodes.OK);
          
            return APIResponse<MemberResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<MemberResponse>> Delete(Guid id)
        {
            var member = await repository.GetByIdAsync<Domain.Entities.Member>(id);
            if(member is null) 
                return APIResponse<MemberResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            int returnValue= await repository.DeleteAsync(member);
            if (returnValue > 0)
                return APIResponse<MemberResponse>.SuccessResponse(mapper.Map<MemberResponse>(member), "Member deleted successfully", APIStatusCodes.OK);

            return APIResponse<MemberResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<IEnumerable<MemberResponse>>> GetAllByConvocation(Guid id)
        {
            var members= await repository.GetAllMembersByConvocation(id);
            if(members is not null && members.Any())
                return APIResponse<IEnumerable<MemberResponse>>.SuccessResponse(members, "success", APIStatusCodes.OK);

            return APIResponse<IEnumerable<MemberResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<MemberResponse>> GetMemberByConvocationId(Guid convocationid, Guid memberId)
        {
            var member = await repository.GetMemberByConvocationId(convocationid, memberId);

            if (member is not null)
                return APIResponse<MemberResponse>.SuccessResponse(member, "success", APIStatusCodes.OK);

            return APIResponse<MemberResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<MemberResponse>> Update(MemberUpdate model)
        {
            Guid id = model.Id ?? contextService.GetUserId();
            var member= await repository.GetByIdAsync<Domain.Entities.Member>(id);
            if (member is  null)
                return APIResponse<MemberResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            var updateMember= mapper.Map(model, member);
            int returnValue= await repository.UpdateAsync(updateMember);
            if (returnValue > 0)
                return APIResponse<MemberResponse>.SuccessResponse(mapper.Map<MemberResponse>(member), "Member Updated successfully", APIStatusCodes.OK);

            return APIResponse<MemberResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }
    }
}
