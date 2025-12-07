using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Entities.Comments.DTOs
{
    public class ActCommentDto
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
