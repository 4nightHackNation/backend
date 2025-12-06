using Microsoft.EntityFrameworkCore;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Repositories;

namespace SciezkaPrawa.Infrastructure.Repositories
{
    public class ActVersionRepository(ApplicationDbContext dbContext) : IActVersionRepository
    {
        public async Task AddAsync(ActVersion version)
        {
            await dbContext.ActVersion.AddAsync(version); 
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActVersion?> GetByIdAsync(Guid id)
        {
            return await dbContext.ActVersion.FirstOrDefaultAsync(av => av.Id == id);
        }

        public async Task UpdateAsync(ActVersion version)
        {
            dbContext.ActVersion.Update(version);       
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActVersion version)
        {
            dbContext.ActVersion.Remove(version);       
            await dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
