using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.Abstractions.IServices
{
    public interface IAttendeService
    {
        Task<APIResponse<AttendeResponse>> Add(AttendeRequest model);


        Task<APIResponse<IEnumerable<AttendeResponse>>> GetAll();


        Task<APIResponse<AttendeResponse>> GetById(Guid id);


        Task<APIResponse<AttendeResponse>> Update(AttendeUpdateRequest model);


        Task<APIResponse<AttendeResponse>> Delete(Guid id);
    }
}
