using InfinityBack.Application.Interface;

namespace InfinityBack.Application.Services
{
    public class FileService : IFileService
    {
        #region Properties
        private readonly IWebHostEnvironment _env;
        #endregion

        #region constructor
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        #endregion

        #region SaveFileAsync
        public async Task<string> SaveFileAsync(IFormFile file, string subfolder)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", subfolder);
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // نرجع الرابط العام الذي يمكن استخدامه في الـ HTML
            return $"/images/{subfolder}/{uniqueFileName}";
        }
        #endregion

        #region DeleteFile
        public void DeleteFile(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return;

            // إزالة الشرطة المائلة الأولى إذا كانت موجودة
            var pathToDelete = relativePath.TrimStart('/');
            var fullPath = Path.Combine(_env.WebRootPath, pathToDelete);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
        #endregion
    }

}
