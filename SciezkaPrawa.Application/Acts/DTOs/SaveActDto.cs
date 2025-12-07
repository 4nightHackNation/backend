using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Acts.DTOs
{
    public class SaveActDto
    {
        public string Title { get; set; } = default!;
        public string PlainLanguageSummary { get; set; } = default!;
        public string Status { get; set; } = "draft";
        public string Priority { get; set; } = "normal";
        public string Sponsor { get; set; } = "normal";

        public string Kadencja { get; set; } = default!;
        public int CurrentStage { get; set; }

        public bool HasConsultation { get; set; }
        public DateTime? ConsultationStart { get; set; }
        public DateTime? ConsultationEnd { get; set; }

        public List<int> TagIds { get; set; } = new();

    }
}
