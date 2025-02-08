﻿using AutoMapper;
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

namespace IUSTConvocation.Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository repository;
    private readonly IMapper mapper;

    public ContactService(IContactRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }


    public async Task<APIResponse<ContactResponse>> Add(ContactRequest model)
    {
        var contact = mapper.Map<Contact>(model);

        var returnResult = await repository.InsertAsync(contact);
        if (returnResult > 0)
        {
            var contactResponse = mapper.Map<ContactResponse>(contact);
            return APIResponse<ContactResponse>.SuccessResponse(contactResponse);
        }
        return APIResponse<ContactResponse>.ErrorResponse("There is some issue please try after sometime", APIStatusCodes.InternalServerError);

    }

    public async Task<APIResponse<ContactResponse>> Delete(Guid id)
    {
        var contact = await repository.GetByIdAsync<Contact>(id);

        if (contact is null)
            return APIResponse<ContactResponse>.ErrorResponse("No Contact found", APIStatusCodes.NotFound);


        int returnValue = await repository.DeleteAsync(contact);

        if (returnValue > 0)
            return APIResponse<ContactResponse>.SuccessResponse(mapper.Map<ContactResponse>(contact));

        return APIResponse<ContactResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);


    }

    public async Task<APIResponse<IEnumerable<ContactResponse>>> GetAll()
    {
       var contacts= await repository.GetAllAsync<Contact>();
        if(contacts.Any())
              return APIResponse<IEnumerable<ContactResponse>>.SuccessResponse(mapper.Map<IEnumerable<ContactResponse>>(contacts));
          
        return APIResponse<IEnumerable<ContactResponse>>.ErrorResponse("No Contact found", APIStatusCodes.NotFound);
    }

    public async Task<APIResponse<ContactResponse>> GetById(Guid id)
    {
        var contact = await repository.GetByIdAsync<Contact>(id);

        if (contact is null)
            return APIResponse<ContactResponse>.ErrorResponse("No Contact found", APIStatusCodes.NotFound);

        return APIResponse<ContactResponse>.SuccessResponse(mapper.Map<ContactResponse>(contact));
    }
}
