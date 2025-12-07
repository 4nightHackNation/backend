using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserFollowedAct> FollowedActs { get; set; } = new List<UserFollowedAct>();
    }
}
