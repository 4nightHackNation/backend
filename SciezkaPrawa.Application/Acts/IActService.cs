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
        Task<IEnumerable<ActListDto>> GetAllAsync();
        Task<ActDetailsDto> GetByIdAsync(Guid id);
        Task<Act> CreateAsync(SaveActDto dto);
        Task UpdateAsync(Guid id, SaveActDto dto);
        Task DeleteAsync(Guid id);
    }
}
