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
using IUSTConvocation.Application.Abstractions.Identity;
using System.Collections;

namespace IUSTConvocation.Application.Services
{
    public class GownService : IGownService
    {
        private readonly IGownRepository repository;
        private readonly IMapper mapper;
        private readonly IFileService fileService;
        private readonly IContextService contextService;

        public GownService(IGownRepository repository, IMapper mapper, IFileService fileService,IContextService contextService )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.fileService = fileService;
            this.contextService = contextService;
        }

        public async Task<APIResponse<GownResponse>> Add(GownRequest model)
        {

            var gownAvail= await repository.FirstOrDefaultAsync<Gown>(x => x.Color == model.Color && x.Size == model.Size);
            if(gownAvail is not null)
                return APIResponse<GownResponse>.ErrorResponse("Gown already added", APIStatusCodes.Conflict);

            var gown = mapper.Map<Gown>(model);

            
            int returnValue = await repository.InsertAsync<Gown>(gown);
            if (returnValue > 0)
            {
                if (model.Files.Any())
                {
                  var uploadedfiles=  await  fileService.UploadFilesAsync(gown.Id, Module.Gown, gown.Id, model.Files);
                   await repository.InsertRangeAsync<AppFile>(uploadedfiles.ToList());
                }
                return APIResponse<GownResponse>.SuccessResponse(mapper.Map<GownResponse>(gown), "Gown added successfully", APIStatusCodes.Created);

            }

            return APIResponse<GownResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<IEnumerable<GownResponse>>> GetAll()
        {
            var gowns = await repository.GetAllGowns();

            if (gowns.Any())
                return APIResponse<IEnumerable<GownResponse>>.SuccessResponse(gowns, $"Found {gowns.Count()} gowns", APIStatusCodes.OK);

            return APIResponse<IEnumerable<GownResponse>>.ErrorResponse("No Gowns found", APIStatusCodes.NoContent);

        }

        public async Task<APIResponse<GownResponse>> GetById(Guid id)
        {
            var gown = await repository.GetGownById(id);

            if (gown is not null)
            {
                return APIResponse<GownResponse>.SuccessResponse(gown, "Successfull", APIStatusCodes.OK);
            }
            return APIResponse<GownResponse>.ErrorResponse("No seat found", APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<GownResponse>> Update(GownUpdateRequest model)
        {

            var gown = await repository.GetByIdAsync<Gown>(model.Id);

            if (gown is null) return APIResponse<GownResponse>.ErrorResponse("No gown found", APIStatusCodes.NotFound);

            var updateGown = mapper.Map(model, gown);

            int returnValue = await repository.UpdateAsync(updateGown);
            if (returnValue > 0)
            {
                return APIResponse<GownResponse>.SuccessResponse(mapper.Map<GownResponse>(updateGown), "Gown updated successfully", APIStatusCodes.OK);
            }

            return APIResponse<GownResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<GownResponse>> Delete(Guid id)
        {

            var gown = await repository.GetByIdAsync<Gown>(id);
            if (gown is null)
            {
                return APIResponse<GownResponse>.ErrorResponse("No gown found", APIStatusCodes.NotFound);
            }

            gown.IsDeleted = true;
            gown.UpdatedOn = DateTimeOffset.Now;
            int returnValue = await repository.UpdateAsync(gown);

            if (returnValue > 0)
            {
                return APIResponse<GownResponse>.SuccessResponse(mapper.Map<GownResponse>(gown), "gown deleted successfully", APIStatusCodes.OK);
            }

            return APIResponse<GownResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<AppFileResponse>> DeleteFile(Guid id)
        {
             var file= await repository.FirstOrDefaultAsync<AppFile>(x => x.Id == id);
            if(file is null)
                return APIResponse<AppFileResponse>.ErrorResponse("No File found", APIStatusCodes.NotFound);

            int returnValue= await repository.DeleteAsync(file);
            if (returnValue > 0)
            {
                await fileService.DeleteFileAsync(file.FilePath);
                return APIResponse<AppFileResponse>.SuccessResponse(mapper.Map<AppFileResponse>(file), "File deleted successfully", APIStatusCodes.OK);
            }
            return APIResponse<AppFileResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<AppFileResponse>> UploadFiles(AppFileRequest model)
        {
            var gown= await repository.FirstOrDefaultAsync<Gown>(x => x.Id == model.EntityId);
            if(gown is null)
                return APIResponse<AppFileResponse>.ErrorResponse("No Gown found", APIStatusCodes.NotFound);

           var filePath = await  fileService.UploadFileAsync( model.File);

            AppFile appFile = new AppFile();

            appFile.Id = Guid.NewGuid();
            appFile.EntityId = contextService.GetUserId();
            appFile.Module = Module.Gown;
            appFile.CreatedBy = contextService.GetUserId();
            appFile.FilePath = filePath;

            int returnValue=  await repository.InsertAsync<AppFile>(appFile);
            if (returnValue > 0)
            {
                //var files = await repository.FindByAsync<AppFile>(x => x.EntityId == model.EntityId);
                    return APIResponse<AppFileResponse>.SuccessResponse(mapper.Map<AppFileResponse>(appFile), "File deleted successfully", APIStatusCodes.OK);
            }
            return APIResponse<AppFileResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<IEnumerable<AppFileResponse>>> GetAllFiles(Guid gownId)
        {
            var files=  await repository.FindByAsync<AppFile>(x => x.EntityId == gownId);
            if (files.Any())
                return APIResponse<IEnumerable<AppFileResponse>>.SuccessResponse(mapper.Map<IEnumerable<AppFileResponse>>(files), "File deleted successfully", APIStatusCodes.OK);
           
            return APIResponse<IEnumerable<AppFileResponse>>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
        }
    }
}
