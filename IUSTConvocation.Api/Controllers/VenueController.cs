using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService service;
        public VenueController(IVenueService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<APIResponse<VenueResponse>> Add([FromBody] VenueRequest model)
        {
            return await service.Add(model);
        }




        [HttpGet]
        public async Task<APIResponse<IEnumerable<VenueResponse>>> GetAll()
        {
            return await service.GetAll();
        }


        [HttpGet("{id:guid}")]
        public Task<APIResponse<VenueResponse>> GetById([FromRoute] Guid id)
        {
            return service.GetById(id);
        }


        [HttpPut]
        public async Task<APIResponse<VenueResponse>> Update([FromBody] VenueUpdateRequest model)
        {
            return await service.Update(model);
        }
    }
}
