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
    public class StageRepository(ApplicationDbContext dbContext) : IStageRepository
    {
        public async Task AddAsync(ActStage stage)
        {
            await dbContext.ActStages.AddAsync(stage);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActStage stage)
        {
            dbContext.ActStages.Remove(stage);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActStage?> GetByIdAsync(Guid id)
        {
            return await dbContext.ActStages.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await dbContext.SaveChangesAsync();
        }
    }
}
