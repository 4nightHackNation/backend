using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Entities
{
    public class Act
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Summary { get; set; }
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public string Urgency { get; set; } = default!;

        public string? Committee { get; set; }
        public string? Sponsor { get; set; }

        public DateTime DateSubmitted { get; set; }
        public DateTime LastUpdated { get; set; }

        public bool HasConsultation { get; set; }
        public DateTime? ConsultationStart { get; set; }
        public DateTime? ConsultationEnd { get; set; }

        public int AmendmentsCount { get; set; }
        public string? PlainLanguageSummary { get; set; }

        public ICollection<ActTag> Tags { get; set; } = new List<ActTag>();
        public ICollection<ActStage> Stages { get; set; } = new List<ActStage>();
        public ICollection<ActVersion> Versions { get; set; } = new List<ActVersion>();
        public ICollection<ActReadingVote> ReadingVotes { get; set; } = new List<ActReadingVote>();
    }
}
