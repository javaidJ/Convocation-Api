using AutoMapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Application.Shared;
using System.IO;
using IUSTConvocation.Application.Abstractions.Identity;
using Microsoft.IdentityModel.Tokens;

namespace IUSTConvocation.Application.Services;

public class StudentService : IStudentService
{

    private readonly IStudentRepository repository;
    private readonly IMapper mapper;
    private readonly IFileService fileService;
    private readonly IContextService contextService;

    public StudentService(IStudentRepository repository, IMapper mapper, IFileService fileService, IContextService contextService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.fileService = fileService;
        this.contextService = contextService;
    }


    public async Task<APIResponse<IEnumerable<StudentResponse>>> GetAll()
    {

        var students = await repository.GetAllStudent();

        if (students is not null && students.Any())
            return APIResponse<IEnumerable<StudentResponse>>.SuccessResponse(students, $"Fount {students.Count()} students");

        return APIResponse<IEnumerable<StudentResponse>>.ErrorResponse("No students found", APIStatusCodes.NoContent);
    }
    

    public async Task<APIResponse<StudentResponse>> GetById(Guid? id)
    {
        var studentId = id ?? contextService.GetUserId();
        var student = await repository.GetStudentById(studentId);

        if (student is not null)
            return APIResponse<StudentResponse>.SuccessResponse(student, $"Success", APIStatusCodes.OK);

        return APIResponse<StudentResponse>.ErrorResponse("No student found", APIStatusCodes.NotFound);

    }
    public async Task<APIResponse<StudentResponse>> Update( StudentRequest model)
    {

        var student = await repository.FirstOrDefaultAsync<Student>(student => student.Id == model.Id);

        if (student is null)
            return APIResponse<StudentResponse>.ErrorResponse("No student found", APIStatusCodes.NotFound);

        var emailExist = await repository.FirstOrDefaultAsync<User>(x => x.Email == model.Email && x.Id != model.Id) is not null;

        if (emailExist)
            return APIResponse<StudentResponse>.ErrorResponse("Email already exists please choose another", APIStatusCodes.Conflict);

        var phoneExist = await repository.FirstOrDefaultAsync<User>(x => x.ContactNo == model.ContactNo && x.Id != model.Id) is not null;

        if (phoneExist)
            return APIResponse<StudentResponse>.ErrorResponse("PhoneNo already exists please choose another", APIStatusCodes.Conflict);

        var updatedStudent = mapper.Map(model, student);
        var user = await repository.GetByIdAsync<User>(student.Id);
        user!.Email = model.Email;
        user.ContactNo = model.ContactNo;
        user.Gender = model.Gender;

        user.Student = updatedStudent;

        if (model.File != null)
        {
            var dbAppFile = await repository.FirstOrDefaultAsync<AppFile>(x => x.EntityId == student.Id);
            if (dbAppFile != null)
            {
                string oldPath = dbAppFile.FilePath;

                dbAppFile.FilePath = await fileService.UploadFileAsync(model.File);

                var returnCode = await repository.UpdateAsync(dbAppFile);
                if (returnCode > 0)
                    await fileService.DeleteFileAsync(oldPath);
            }
            else
            {
                string path = await fileService.UploadFileAsync(model.File);
                AppFile file = new()
                {
                    Module = Domain.Enums.Module.Student,
                    CreatedBy = contextService.GetUserId(),
                    CreatedOn = DateTimeOffset.Now,
                    EntityId = student.Id,
                    FilePath = path
                };

                var returnCode = await repository.InsertAsync(file);
            }
        }
       
        int returnValue = await repository.UpdateAsync<User>(user);
        if (returnValue > 0)
        {
            var studentResponse = await repository.GetStudentById(student.Id);
            if (studentResponse != null)
                return APIResponse<StudentResponse>.SuccessResponse(studentResponse, "Student updated successfully", APIStatusCodes.OK);
        }
        return APIResponse<StudentResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
    }


    public async Task<APIResponse<StudentResponse>> Delete(Guid id)
    {

        var student = await repository.GetByIdAsync<Student>(id);

        if (student is null)
            return APIResponse<StudentResponse>.ErrorResponse("No student found", APIStatusCodes.NotFound);

        student.IsDeleted = true;

        int returnValue = await repository.UpdateAsync<Student>(student);
        if (returnValue > 0)
            return APIResponse<StudentResponse>.SuccessResponse(mapper.Map<StudentResponse>(student), "Student deleted successfully", APIStatusCodes.OK);

        return APIResponse<StudentResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }
}
