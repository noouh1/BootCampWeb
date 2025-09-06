namespace WebApplication1.Services.Interfaces;

public interface IFileUpload
{
    Task<string> SaveFileAsync(IFormFile file, string folderName);
}