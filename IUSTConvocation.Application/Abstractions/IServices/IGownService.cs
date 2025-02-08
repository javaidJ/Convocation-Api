using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;


namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IGownService
{
    Task<APIResponse<GownResponse>> Add(GownRequest model);

    Task<APIResponse<IEnumerable<GownResponse>>> GetAll();

    Task<APIResponse<GownResponse>> GetById(Guid id);

    Task<APIResponse<GownResponse>> Update(GownUpdateRequest model);

    Task<APIResponse<GownResponse>> Delete(Guid id);

    Task<APIResponse<AppFileResponse>> DeleteFile(Guid id);

    Task<APIResponse<AppFileResponse>> UploadFiles(AppFileRequest model);

    Task<APIResponse<IEnumerable<AppFileResponse>>> GetAllFiles(Guid id);


}
