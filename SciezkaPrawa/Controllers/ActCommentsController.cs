using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Comments;
using SciezkaPrawa.Domain.Entities.Comments.DTOs;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/acts/{actId:guid}/comments")]
    public class ActCommentsController(IActCommentsService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActCommentDto>>> Get(Guid actId)
        {
            var comments = await service.GetForActAsync(actId);
            return Ok(comments);
        }

        [HttpPost]
        [Authorize(Roles = "User,Officier")] 
        public async Task<ActionResult<ActCommentDto>> Add(Guid actId, [FromBody] SaveActCommentDto dto)
        {
            var created = await service.AddAsync(actId, dto);
            return CreatedAtAction(nameof(Get), new { actId }, created);
        }
    }
}
