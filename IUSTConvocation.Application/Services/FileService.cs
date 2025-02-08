using IUSTConvocation.Application.Abstractions.IServices;
using Microsoft.AspNetCore.Http;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using IUSTConvocation.Application.Abstractions.IRepositories;

namespace IUSTConvocation.Application.Services;

public class FileService : IFileService
{
    private readonly string webRootPath;

    public FileService(string webRootPath)
    {
        this.webRootPath = webRootPath;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        string path = GetPhysicalDirPath();


        if (!(Directory.Exists(path)))
            Directory.CreateDirectory(path);


        string fileName = string.Concat(Guid.NewGuid(), file.FileName);
        string fullPath = Path.Combine(path, fileName);


        using FileStream fs = new(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);



        //return Path.Combine(GetRelativeDirPath(), fileName);
        return Path.Combine("Files", fileName);

    }


    public async Task<IEnumerable<AppFile>> UploadFilesAsync(Guid entityId, Module module, Guid createdBy, IFormFileCollection files)
    {
        List<AppFile> appFiles = new List<AppFile>();
        string path = GetPhysicalDirPath();


        if (!(Directory.Exists(path)))
            Directory.CreateDirectory(path);

        foreach (var file in files)
        {

            string fileName = string.Concat(Guid.NewGuid(), file.FileName);
            string fullPath = Path.Combine(path, fileName);

            using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            AppFile appFile = new AppFile();

            appFile.Id = Guid.NewGuid();
            appFile.EntityId = entityId;
            appFile.Module = module;
            appFile.CreatedBy = createdBy;
            appFile.FilePath = Path.Combine("Files", fileName);

            //if (file.ContentType.StartsWith("video"))
            //{
            //    appFile.IsVideo = true;
            //}

            appFiles.Add(appFile);
        }
        return appFiles;
    }


    public async Task<bool> DeleteFileAsync(string filePath)
    {

        string fullPath = Path.Combine(webRootPath, filePath);

        if (!(File.Exists(fullPath))) return false;

        await Task.Run(() => File.Delete(fullPath));

        if (!(File.Exists(fullPath))) return false;

        return true;

    }


    public Task<bool> DeleteFilesAsync(IEnumerable<string> filePaths)
    {
        throw new NotImplementedException();
    }


    public async Task<string> ReadEmailTemplate(string templateName)
    {
        string templatePath = Path.Combine(@"EmailTemplates", templateName);
        var res = File.Exists(templatePath);
        if (!File.Exists(templatePath))
            return string.Empty;

        return await Task.Run(() => File.ReadAllText(templatePath));

    }

    #region helper func
    //private string GetPhysicalDirPath() => Path.Combine(webRootPath, "Files", "Images");
    private string GetPhysicalDirPath() => Path.Combine(webRootPath, "Files");


    //private string GetRelativeDirPath() => Path.Combine("Files", "Images");


    #endregion
}
