using SciezkaPrawa.Application.Tags.DTOs;
using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Acts.DTOs
{
    public class ActDetailsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public string? Kadencja { get; set; } = default!;
        public int CurrentStage { get; set; }
        public string? Sponsor { get; set; }

        public DateTime DateSubmitted { get; set; }
        public DateTime LastUpdated { get; set; }

        public bool HasConsultation { get; set; }
        public DateTime? ConsultationStart { get; set; }
        public DateTime? ConsultationEnd { get; set; }

        public string? PlainLanguageSummary { get; set; }

        public List<TagDto> Tags { get; set; } = new();
        public List<ActStage> Stages { get; set; } = new();
        public List<ActVersion> Versions { get; set; } = new();
        public List<ActReadingVote> ReadingVotes { get; set; } = new();
    }
}
