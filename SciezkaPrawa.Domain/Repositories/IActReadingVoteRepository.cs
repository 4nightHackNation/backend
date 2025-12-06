using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Repositories
{
    public interface IActReadingVoteRepository
    {
        Task AddAsync(ActReadingVote vote);
        Task<ActReadingVote?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
        Task DeleteAsync(ActReadingVote vote);
    }
}
