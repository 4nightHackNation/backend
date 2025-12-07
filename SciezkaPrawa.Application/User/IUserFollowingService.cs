using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.User
{
    public interface IUserFollowingService
    {
        Task FollowAsync(string username, Guid actId);
        Task UnfollowAsync(string username, Guid actId);
        Task<IEnumerable<Act>> GetFollowedActsAsync(string username);

    }
}
