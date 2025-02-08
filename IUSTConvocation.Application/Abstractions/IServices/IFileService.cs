using Microsoft.AspNetCore.Http;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IFileService
{

    Task<string> UploadFileAsync(IFormFile file);


    //Task<IEnumerable<string>> UploadFilesAsync(IFormFileCollection files);
    Task<IEnumerable<AppFile>> UploadFilesAsync(Guid entityId, Module module, Guid createdBy, IFormFileCollection files);


    Task<bool> DeleteFileAsync(string filePath);


    Task<bool> DeleteFilesAsync(IEnumerable<string> filePaths);


    Task<string> ReadEmailTemplate(string templateName);

}
