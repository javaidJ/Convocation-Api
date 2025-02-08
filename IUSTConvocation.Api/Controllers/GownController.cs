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
    public class GownController : ControllerBase
    {
        private readonly IGownService service;
        public GownController(IGownService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<APIResponse<GownResponse>> Add([FromForm] GownRequest model)
        {
            return await service.Add(model);
        }


        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<GownResponse>> Delete(Guid id)
        {
            return await service.Delete(id);
        }


        [HttpDelete("file/{id:guid}")]
        public async Task<APIResponse<AppFileResponse>> DeleteFile(Guid id)
        {
            return await service.DeleteFile(id);
        }


        [HttpGet]
        public async Task<APIResponse<IEnumerable<GownResponse>>> GetAll()
        {
            return await service.GetAll();
        }


        [HttpGet("files/{gownid:guid}")]
        public async Task<APIResponse<IEnumerable<AppFileResponse>>> GetAllFiles(Guid gownid)
        {
            return await service.GetAllFiles(gownid);
        }


        [HttpGet("{id:guid}")]
        public Task<APIResponse<GownResponse>> GetById([FromRoute] Guid id)
        {
            return service.GetById(id);
        }


        [HttpPut]
        public async Task<APIResponse<GownResponse>> Update([FromBody] GownUpdateRequest model)
        {
            return await service.Update(model);
        }


        [HttpPut("uploadfiles")]
        public async Task<APIResponse<AppFileResponse>> UploadFiles([FromForm]AppFileRequest model)
        {
            return await service.UploadFiles(model);
        }
    }
}
