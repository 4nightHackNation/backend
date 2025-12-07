using SciezkaPrawa.Application.Tags.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Acts.DTOs
{
    public class ActListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public int Kadencja { get; set; }
        public int CurrentStage { get; set; }
        public string? Sponsor { get; set; }

        public DateTime DateSubmitted { get; set; }
        public DateTime LastUpdated { get; set; }

        public bool HasConsultation { get; set; }
        public DateTime? ConsultationStart { get; set; }
        public DateTime? ConsultationEnd { get; set; }

        public int AmendmentsCount { get; set; }
        public List<TagDto> Tags { get; set; } = new();
    }
}
