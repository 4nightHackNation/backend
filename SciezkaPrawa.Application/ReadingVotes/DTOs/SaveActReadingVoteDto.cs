using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.ReadingVotes.DTOs
{
    public class SaveActReadingVoteDto
    {
        public string ReadingName { get; set; } = default!;
        public int For { get; set; }
        public int Against { get; set; }
        public int Abstain { get; set; }
        public DateTime? Date { get; set; }
    }
}
