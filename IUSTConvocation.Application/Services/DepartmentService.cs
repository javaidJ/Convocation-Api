using AutoMapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Application.Services;

public class DepartmentService : IDepartmentService
{

    private readonly IDepartmentRepository repository;
    private readonly IMapper mapper;
    public DepartmentService(IDepartmentRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<APIResponse<DepartmentResponse>> Add(DepartmentRequest model)
    {

        if (await repository.FirstOrDefaultAsync<Department>(department => department.DepartmentName == model.DepartmentName) is not null)
            return APIResponse<DepartmentResponse>.ErrorResponse("Department already exists", APIStatusCodes.BadRequest);


        var department = mapper.Map<Department>(model);


        int returnValue = await repository.InsertAsync<Department>(department);
        if (returnValue > 0)
            return APIResponse<DepartmentResponse>.SuccessResponse(mapper.Map<DepartmentResponse>(department), "Department added successfully", APIStatusCodes.Created);

        return APIResponse<DepartmentResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }


    public async Task<APIResponse<IEnumerable<DepartmentResponse>>> GetAll()
    {

        var departments = await repository.GetAllAsync<Department>();

        if (departments.Any())
            return APIResponse<IEnumerable<DepartmentResponse>>.SuccessResponse(mapper.Map<IEnumerable<DepartmentResponse>>(departments), $"Found {departments.Count()} departments", APIStatusCodes.OK);

        return APIResponse<IEnumerable<DepartmentResponse>>.ErrorResponse("No departments found", APIStatusCodes.NotFound);

    }

    public async Task<APIResponse<DepartmentResponse>> GetById(Guid id)
    {

        var department = await repository.GetByIdAsync<Department>(id);

        if (department is not null)
            return APIResponse<DepartmentResponse>.SuccessResponse(mapper.Map<DepartmentResponse>(department), "Success", APIStatusCodes.OK);

        return APIResponse<DepartmentResponse>.ErrorResponse("No department found", APIStatusCodes.NotFound);

    }

    public async Task<APIResponse<DepartmentResponse>> Update(DepartmentUpdateRequest model)
    {

        var departemnt = await repository.GetByIdAsync<Department>(model.Id);

        if (departemnt is null)
            return APIResponse<DepartmentResponse>.ErrorResponse("No department found", APIStatusCodes.NotFound);


        var updatedDepartment = mapper.Map(model, departemnt);

        int returnValue = await repository.UpdateAsync<Department>(updatedDepartment);

        if (returnValue > 0)
            return APIResponse<DepartmentResponse>.SuccessResponse(mapper.Map<DepartmentResponse>(updatedDepartment), "Department updated successfully", APIStatusCodes.OK);

        return APIResponse<DepartmentResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }



    public async Task<APIResponse<DepartmentResponse>> Delete(Guid id)
    {

        var department = await repository.GetByIdAsync<Department>(id);

        if (department is null)
            return APIResponse<DepartmentResponse>.ErrorResponse("No department found", APIStatusCodes.NotFound);


        int returnValue = await repository.DeleteAsync<Department>(department);
        if (returnValue > 0)
            return APIResponse<DepartmentResponse>.SuccessResponse(mapper.Map<DepartmentResponse>(department), "Departemnt deleted successfully", APIStatusCodes.OK);

        return APIResponse<DepartmentResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

    }


}
