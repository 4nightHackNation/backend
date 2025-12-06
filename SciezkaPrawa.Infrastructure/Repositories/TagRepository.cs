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
    public class TagRepository(ApplicationDbContext dbContext) : ITagRepository
    {
        public async Task AddAsync(Tag tag)
        {
            await dbContext.Tags.AddAsync(tag);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tag tag)
        {
            dbContext.Remove(tag);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await dbContext.Tags.ToListAsync();
            return tags;
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            var tag = await dbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
            return tag;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
