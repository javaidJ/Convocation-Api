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
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService service;
        public SeatsController(ISeatService service)
        {
            this.service = service;
        }


        [HttpPost]
        public Task<APIResponse<SeatResponse>> Add([FromBody] SeatRequest model)
        {
            return service.Add(model);
        }


        [HttpDelete("{id:guid}")]
        public Task<APIResponse<SeatResponse>> Delete([FromRoute] Guid id)
        {
            return service.Delete(id);
        }


        [HttpGet("venue/{id:guid}")]
        public Task<APIResponse<IEnumerable<SeatResponse>>> GetAll(Guid id)
        {
            return service.GetAllSeatsByVenue(id);
        }


        [HttpGet("{id:guid}")]
        public Task<APIResponse<SeatResponse>> GetById([FromRoute] Guid id)
        {
            return service.GetById(id);
        }


        [HttpPut]
        public Task<APIResponse<SeatResponse>> Update([FromBody] SeatUpdateRequest model)
        {
            return service.Update(model);
        }
    }
}
