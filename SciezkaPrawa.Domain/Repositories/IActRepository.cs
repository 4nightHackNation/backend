using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Repositories
{
    public interface IActRepository
    {
        Task<IEnumerable<Act>> GetAllAsync();
        Task<Act?> GetByIdAsync(Guid id);
        Task<Act?> GetDetailsByIdAsync(Guid id);
        Task AddAsync(Act act);
        Task DeleteAsync(Act act);
        Task SaveChangesAsync();
    }
}
