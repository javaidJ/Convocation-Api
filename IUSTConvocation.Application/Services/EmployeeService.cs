using AutoMapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Application.Shared;
using System.Reflection.Metadata.Ecma335;
using IUSTConvocation.Application.Abstractions.Identity;

namespace IUSTConvocation.Application.Services;

public class EmployeeService : IEmployeeService
{

    private readonly IEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly IFileService fileService;
    private readonly IContextService contextService;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper, IFileService fileService, IContextService contextService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.fileService = fileService;
        this.contextService = contextService;
    }

  
    public async Task<APIResponse<EmployeeResponse>> Delete(Guid id)
    {
        var employee = await repository.GetByIdAsync<Employee>(id);

        if (employee is null)
        {
            return APIResponse<EmployeeResponse>.ErrorResponse("No employee found", APIStatusCodes.NotFound);
        }

        employee.IsDeleted = true;
        var returnValue= await repository.UpdateAsync(employee);
        return returnValue switch
        {
            > 0 => APIResponse<EmployeeResponse>.SuccessResponse(mapper.Map<EmployeeResponse>(employee), "Employee deleted successfully", APIStatusCodes.OK),
            _ => APIResponse<EmployeeResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError)
        };
    }

    public async Task<APIResponse<IEnumerable<EmployeeResponse>>> GetAll()
    {
        var employees = await repository.GetAllEmployees();
        if(employees is not null && employees.Any()) 
            return APIResponse<IEnumerable<EmployeeResponse>>.SuccessResponse(employees, $"Found {employees.Count()} employees", APIStatusCodes.OK);

        return APIResponse<IEnumerable<EmployeeResponse>>.ErrorResponse("No employees found", APIStatusCodes.NoContent);
    }

    public async Task<APIResponse<EmployeeResponse>> GetById(Guid? id)
    {
        Guid empId = id ?? contextService.GetUserId();
        var employee = await repository.GetEmployeeById(empId);

        if (employee is not null)
            return APIResponse<EmployeeResponse>.SuccessResponse(employee, "Employee found", APIStatusCodes.OK);
      
                return APIResponse<EmployeeResponse>.ErrorResponse("No employee found", APIStatusCodes.NotFound);
    }


    public async Task<APIResponse<EmployeeResponse>> Update(EmployeeRequest model)
    {
        var employee = await repository.FirstOrDefaultAsync<Employee>(emp => emp.Id == model.Id);

        if (employee is null)
            return APIResponse<EmployeeResponse>.ErrorResponse("No employee found", APIStatusCodes.NotFound);

        var emailExist = await repository.FirstOrDefaultAsync<User>(x => x.Email == model.Email && x.Id != model.Id) is not null;

        if (emailExist)
            return APIResponse<EmployeeResponse>.ErrorResponse("Email already exists please choose another", APIStatusCodes.Conflict);

        var phoneExist = await repository.FirstOrDefaultAsync<User>(x => x.ContactNo == model.ContactNo && x.Id != model.Id) is not null;

        if (phoneExist)
            return APIResponse<EmployeeResponse>.ErrorResponse("PhoneNo already exists please choose another", APIStatusCodes.Conflict);

        var updateEmployee = mapper.Map(model, employee);

        var user = await repository.GetByIdAsync<User>(employee.Id);
        user!.Email = model.Email;
        user.ContactNo = model.ContactNo;
        user.Gender = model.Gender;

        user.Employee = updateEmployee;

        if (model.File != null)
        {
            var dbAppFile = await repository.FirstOrDefaultAsync<AppFile>(x => x.EntityId == employee.Id);
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
                    Module = Domain.Enums.Module.Employee,
                    CreatedBy = contextService.GetUserId(),
                    CreatedOn = DateTimeOffset.Now,
                    EntityId = employee.Id,
                    FilePath = path
                };

                var returnCode = await repository.InsertAsync(file);
            }
        }

        int returnValue = await repository.UpdateAsync<User>(user);
        if (returnValue > 0)
        {
            var employeeResponse = await repository.GetEmployeeById(employee.Id);
            if (employeeResponse != null)
                return APIResponse<EmployeeResponse>.SuccessResponse(employeeResponse, "Employee updated successfully", APIStatusCodes.OK);
        }
        return APIResponse<EmployeeResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
    }
}
