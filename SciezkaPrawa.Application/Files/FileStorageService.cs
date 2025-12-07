using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Files
{
    public class FileStorageService(FileStorageOptions options) : IFileStorageService
    {
        public async Task<string> SavePdfAsync(Stream fileStream, string fileName, Guid actId, Guid versionId)
        {
            var root = Path.IsPathRooted(options.RootPath)
                ? options.RootPath
                : Path.Combine(Directory.GetCurrentDirectory(), options.RootPath);

            var actFolder = Path.Combine(root, actId.ToString());
            if (!Directory.Exists(actFolder))
            {
                Directory.CreateDirectory(actFolder);
            }

            var safeFileName = $"{versionId}.pdf";
            var fullPath = Path.Combine(actFolder, safeFileName);

            using (var file = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await fileStream.CopyToAsync(file);
            }

            var relativePath = Path.Combine(actId.ToString(), safeFileName);

            return relativePath.Replace("\\", "/");
        }
    }
}
