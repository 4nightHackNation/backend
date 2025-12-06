using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Application.Tags.DTOs;
using SciezkaPrawa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Tags
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag?> GetById(int id);
        Task<Tag> CreateAsync(SaveTagDto dto);
        Task UpdateAsync(int id, SaveTagDto dto);
        Task DeleteAsync(int id);
    }
}
