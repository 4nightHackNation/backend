using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Acts;
using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Domain.Entities;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/acts")]
    public class AtcsController(IActService actService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Act>>> GetAllActs()
        {

            var acts = await actService.GetAllAsync();
            return Ok(acts);
        }

        [HttpGet("acts/id")]
        public async Task<ActionResult<Act>> GetById(Guid id)
        {

            var acts = await actService.GetById(id);
            return Ok(acts);
        }

        [HttpPost]
        public async Task<ActionResult<Act>> CreateAct([FromBody] SaveActDto dto)
        {
            var created = await actService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, SaveActDto dto)
        {
            await actService.UpdateAsync(id, dto);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAct(Guid id)
        {
            await actService.DeleteAsync(id);
            return NoContent();
        }

    }
}
