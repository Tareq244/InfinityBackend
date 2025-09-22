namespace InfinityBack.Application.Interface
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string subfolder);
        void DeleteFile(string relativePath);
    }
}
