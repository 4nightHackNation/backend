using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Acts;
using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Application.Tags;
using SciezkaPrawa.Application.Tags.DTOs;
using SciezkaPrawa.Domain.Entities;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagsController(ITagService tagService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllActs()
        {

            var acts = await tagService.GetAllAsync();
            return Ok(acts);
        }

        [HttpGet("tags/id")]
        public async Task<ActionResult<Tag>> GetById(int id)
        {

            var tags = await tagService.GetById(id);
            return Ok(tags);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag([FromBody] SaveTagDto dto)
        {
            var created = await tagService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAct(int id, [FromBody] SaveTagDto dto)
        {
            await tagService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAct(int id)
        {
            await tagService.DeleteAsync(id);
            return NoContent();
        }
    }
}
