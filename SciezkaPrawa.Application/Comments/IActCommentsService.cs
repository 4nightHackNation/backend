using SciezkaPrawa.Domain.Entities.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Comments
{
    public interface IActCommentsService
    {
        Task<ActCommentDto> AddAsync(Guid actId, SaveActCommentDto dto);
        Task<IEnumerable<ActCommentDto>> GetForActAsync(Guid actId);
    }
}
