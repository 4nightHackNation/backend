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
        public string? Summary { get; set; }

        public string Status { get; set; } = "draft";
        public string Priority { get; set; } = "normal";
        public string Urgency { get; set; } = "normal";

        public string? Committee { get; set; }
        public string? Sponsor { get; set; }

        public bool HasConsultation { get; set; }
        public DateTime? ConsultationStart { get; set; }
        public DateTime? ConsultationEnd { get; set; }

        public int AmendmentsCount { get; set; } = 0;
        public List<int> TagIds { get; set; } = new();

    }
}
