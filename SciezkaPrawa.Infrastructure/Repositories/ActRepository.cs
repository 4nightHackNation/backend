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
    public class ActRepository(ApplicationDbContext dbContext) : IActRepository
    {
        public async Task AddAsync(Act act)
        {
            await dbContext.Acts.AddAsync(act);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Act act)
        {
            dbContext.Remove(act);
        }

        public async Task<IEnumerable<Act>> GetAllAsync()
        {
            var acts = await dbContext.Acts.ToListAsync();
            return acts;
        }

        public async Task<Act?> GetByIdAsync(Guid id)
        {
            var act = await dbContext.Acts.FirstOrDefaultAsync(a => a.Id == id);
            return act;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
