using Microsoft.AspNetCore.Identity;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using SciezkaPrawa.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.User
{
    public class UserFollowingService(
    UserManager<ApplicationUser> userManager,
    IUserFollowRepository followRepo
    ) : IUserFollowingService
    {
        public async Task FollowAsync(string username, Guid actId)
        {
            var user = await userManager.FindByNameAsync(username)
                ?? throw new NotFoundException(nameof(ApplicationUser), username);

            await followRepo.FollowAsync(user.Id, actId);
        }

        public async Task UnfollowAsync(string username, Guid actId)
        {
            var user = await userManager.FindByNameAsync(username)
                ?? throw new NotFoundException(nameof(ApplicationUser), username);

            await followRepo.UnfollowAsync(user.Id, actId);
        }

        public async Task<IEnumerable<Act>> GetFollowedActsAsync(string username)
        {
            var user = await userManager.FindByNameAsync(username)
                ?? throw new NotFoundException(nameof(ApplicationUser), username);

            return await followRepo.GetFollowedActsAsync(user.Id);
        }
    }
}
