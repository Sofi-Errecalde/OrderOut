namespace OrderOut.Services.photo
{
    

    public class PhotoService
    {
        private readonly IWebHostEnvironment _environment;

        public PhotoService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadPhotoAsync(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
                throw new ArgumentException("No file uploaded.");

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, photo.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            return $"{photo.FileName}";
        }

        public byte[] GetPhoto(string fileName, out string contentType)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException();

            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return System.IO.File.ReadAllBytes(filePath);
        }
    }
    
}
