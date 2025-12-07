using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Repositories
{
    public interface IUserFollowRepository
    {
        Task FollowAsync(string userId, Guid actId);
        Task UnfollowAsync(string userId, Guid actId);
        Task<bool> IsFollowingAsync(string userId, Guid actId);
        Task<IEnumerable<Act>> GetFollowedActsAsync(string userId);
    }
}
