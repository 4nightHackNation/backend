using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.ReadingVotes;
using SciezkaPrawa.Application.ReadingVotes.DTOs;
using SciezkaPrawa.Domain.Entities;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/acts/{actId:guid}/reading-votes")]
    public class ReadingVotesController(IActReadingVotesService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ActReadingVote>> Create(Guid actId, [FromBody] SaveActReadingVoteDto dto)
        {
            var created = await service.CreateAsync(actId, dto);
            return CreatedAtAction(
                nameof(GetById),
                new { actId, voteId = created.Id },
                created);
        }

        [HttpGet("{voteId:guid}")]
        public async Task<ActionResult<ActReadingVote>> GetById(Guid actId, Guid voteId)
        {
            var vote = await service.GetByIdAsync(actId, voteId);
            return Ok(vote);
        }

        [HttpPut("{voteId:guid}")]
        public async Task<IActionResult> Update(Guid actId, Guid voteId, [FromBody] SaveActReadingVoteDto dto)
        {
            await service.UpdateAsync(actId, voteId, dto);
            return NoContent();
        }

        [HttpDelete("{voteId:guid}")]
        public async Task<IActionResult> Delete(Guid actId, Guid voteId)
        {
            await service.DeleteAsync(actId, voteId);
            return NoContent();
        }
    }

}
