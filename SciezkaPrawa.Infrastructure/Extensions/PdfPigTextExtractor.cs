using SciezkaPrawa.Application.Files;
using SciezkaPrawa.Application.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace SciezkaPrawa.Infrastructure.Extensions
{
    public class PdfPigTextExtractor(FileStorageOptions options) : IPdfTextExtractor
    {
        public string ExtractText(string filePath)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "acts");

            var fullPath = Path.IsPathRooted(filePath)
                ? filePath
                : Path.Combine(root, filePath);

            Console.WriteLine($"[PdfPig] filePath from DB: {filePath}");
            Console.WriteLine($"[PdfPig] fullPath resolved: {fullPath}");

            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Plik PDF nie został znaleziony.", fullPath);

            var sb = new StringBuilder();

            using (var document = PdfDocument.Open(fullPath))
            {
                foreach (var page in document.GetPages())
                {
                    sb.AppendLine(page.Text);
                }
            }

            return sb.ToString();
        }
    }
}

