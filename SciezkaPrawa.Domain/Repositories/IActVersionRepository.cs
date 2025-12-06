using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Repositories
{
    public interface IActVersionRepository
    {
        Task AddAsync(ActVersion version);
        Task<ActVersion?> GetByIdAsync(Guid id);
        Task DeleteAsync(ActVersion version);
        Task SaveChangesAsync();
    }
}
