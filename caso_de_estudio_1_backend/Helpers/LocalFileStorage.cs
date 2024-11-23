namespace caso_de_estudio_1_backend.Helpers
{
    public class LocalFileStorage
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocalFileStorage(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task deleteFile(string rute, string container)
        {
            if (rute != null)
            {
                var fileName = Path.GetFileName(rute);
                var directory = Path.Combine(_env.WebRootPath, container, fileName);
                if (File.Exists(directory))
                {
                    File.Delete(directory);
                }
            }
            return Task.FromResult(0);

        }

        public async Task<string> EditFile(byte[] content, string extension, string container, string rute, string contentType)
        {
            await deleteFile(rute, container);
            return await SaveFile(content, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, container);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string ruta = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(ruta, content);

            var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var urlDB = Path.Combine(url, container, fileName).Replace("\\", "/");
            return urlDB;
        }
    }
}
