using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Repositories
{
    public interface IStageRepository
    {
        Task<ActStage?> GetByIdAsync(Guid id);
        Task AddAsync(ActStage stage);
        Task SaveChangesAsync();
        Task DeleteAsync(ActStage stage);
    }
}
