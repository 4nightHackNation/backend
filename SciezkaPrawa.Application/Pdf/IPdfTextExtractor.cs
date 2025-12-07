using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Pdf
{
    public interface IPdfTextExtractor
    {
        string ExtractText(string filePath);
    }
}
