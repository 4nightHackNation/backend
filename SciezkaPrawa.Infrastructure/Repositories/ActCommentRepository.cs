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
    public class ActCommentRepository(ApplicationDbContext dbContext) : IActCommentRepository
    {
        public async Task AddAsync(ActComment comment)
        {
            await dbContext.ActComments.AddAsync(comment);
        }

        public async Task<IEnumerable<ActComment>> GetByActIdAsync(Guid actId)
        {
            return await dbContext.ActComments
                .Where(c => c.ActId == actId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
