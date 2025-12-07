using SciezkaPrawa.Application.User;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Entities.Comments.DTOs;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Comments
{
    public class ActCommentsService(IActCommentRepository commentRepo,
         IActRepository actRepo,
         ICurrentUserService currentUser) : IActCommentsService
    {
        public async Task<ActCommentDto> AddAsync(Guid actId, SaveActCommentDto dto)
        {
            if (!currentUser.IsAuthenticated)
                throw new UnauthorizedAccessException("Musisz być zalogowany, aby dodać komentarz.");

            var act = await actRepo.GetByIdAsync(actId)
                      ?? throw new NotFoundException(nameof(Act), actId.ToString());

            var comment = new ActComment
            {
                Id = Guid.NewGuid(),
                ActId = actId,
                AuthorId = currentUser.UserId!,
                AuthorName = currentUser.UserName,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
            };

            await commentRepo.AddAsync(comment);
            await commentRepo.SaveChangesAsync();

            return new ActCommentDto
            {
                Id = comment.Id,
                AuthorName = comment.AuthorName,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }

        public async Task<IEnumerable<ActCommentDto>> GetForActAsync(Guid actId)
        {
            var comments = await commentRepo.GetByActIdAsync(actId);

            return comments.Select(c => new ActCommentDto
            {
                Id = c.Id,
                AuthorName = c.AuthorName,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            });
        }
    }
}
