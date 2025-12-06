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
    public class ActReadingVoteRepository(ApplicationDbContext dbContext) : IActReadingVoteRepository
    {
        public async Task AddAsync(ActReadingVote vote)
        {
            await dbContext.ActReadingVotes.AddAsync(vote);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActReadingVote vote)
        {
            dbContext.ActReadingVotes.Remove(vote);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActReadingVote?> GetByIdAsync(Guid id)
        {
            return await dbContext.ActReadingVotes
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
