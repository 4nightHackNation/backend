using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Entities
{
    public class ActComment
    {
        public Guid Id { get; set; }
        public Guid ActId { get; set; }
        public Act Act { get; set; } = default!;
        public string AuthorId { get; set; } = default!;
        public string AuthorName { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

    }
}
