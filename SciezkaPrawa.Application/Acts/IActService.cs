using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Acts
{
    public interface IActService
    {
        Task<IEnumerable<Act>> GetAllAsync();
        Task<Act?> GetById(Guid id);
        Task<Act> CreateAsync(SaveActDto dto);
    }
}
