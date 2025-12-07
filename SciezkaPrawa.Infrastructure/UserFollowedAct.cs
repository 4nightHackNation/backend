using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Infrastructure
{
    public class UserFollowedAct
    {
        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;

        public Guid ActId { get; set; }
        public Act Act { get; set; } = default!;

    }
}
