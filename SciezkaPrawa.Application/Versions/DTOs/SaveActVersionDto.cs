using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Versions.DTOs
{
    public class SaveActVersionDto
    {
        public int VersionNumber { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = default!;
        public string FilePath { get; set; } = default!;
    }
}
