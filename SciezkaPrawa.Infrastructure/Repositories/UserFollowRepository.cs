using Microsoft.EntityFrameworkCore;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Infrastructure.Repositories
{
    public class UserFollowRepository(ApplicationDbContext db) : IUserFollowRepository
    {
        public async Task FollowAsync(string userId, Guid actId)
        {
            if (await db.UserFollowedActs.FindAsync(userId, actId) != null)
                return;

            db.UserFollowedActs.Add(new UserFollowedAct
            {
                UserId = userId,
                ActId = actId
            });

            await db.SaveChangesAsync();
        }

        public async Task UnfollowAsync(string userId, Guid actId)
        {
            var entity = await db.UserFollowedActs.FindAsync(userId, actId);
            if (entity == null) return;

            db.UserFollowedActs.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<bool> IsFollowingAsync(string userId, Guid actId)
        {
            return await db.UserFollowedActs.AnyAsync(x => x.UserId == userId && x.ActId == actId);
        }

        public async Task<IEnumerable<Act>> GetFollowedActsAsync(string userId)
        {
            return await db.UserFollowedActs
                .Where(x => x.UserId == userId)
                .Include(x => x.Act)
                .Select(x => x.Act)
                .ToListAsync();
        }
    }
}
