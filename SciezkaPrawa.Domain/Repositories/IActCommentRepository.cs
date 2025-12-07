using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Domain.Repositories
{
    public interface IActCommentRepository
    {
        Task AddAsync(ActComment comment);
        Task<IEnumerable<ActComment>> GetByActIdAsync(Guid actId);
        Task SaveChangesAsync();
    }
}
