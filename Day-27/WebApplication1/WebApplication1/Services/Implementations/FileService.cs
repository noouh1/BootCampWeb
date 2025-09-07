using EmailServiceApp.Services;
using WebApplication1.Models.Emails;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class FileService(ServerSetting serverSetting) : IFileService
{
    private readonly string _mainDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    
    public string? GetFilePath(string? filePath)
    {
        return string.IsNullOrEmpty(filePath) ? null : Path.Combine(_mainDirectory, filePath);
    }
}
