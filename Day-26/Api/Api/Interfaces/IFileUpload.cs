namespace Api.Interfaces
{
    public interface IFileUpload
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
    }
}
