using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Versions;
using SciezkaPrawa.Application.Versions.DTOs;
using SciezkaPrawa.Domain.Entities;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/acts/{actId:guid}/versions")]
    public class ActVersionsController(IActVersionsService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ActVersion>> Create(Guid actId, [FromBody] SaveActVersionDto dto)
        {
            var created = await service.CreateAsync(actId, dto);
            return CreatedAtAction(
                nameof(GetById),
                new { actId, versionId = created.Id },
                created);
        }

        [HttpGet("{versionId:guid}")]
        public async Task<ActionResult<ActVersion>> GetById(Guid actId, Guid versionId)
        {
            var version = await service.GetByIdAsync(actId, versionId);
            return Ok(version);
        }

        [HttpPut("{versionId:guid}")]
        public async Task<IActionResult> Update(Guid actId, Guid versionId, [FromBody] SaveActVersionDto dto)
        {
            await service.UpdateAsync(actId, versionId, dto);
            return NoContent();
        }

        [HttpDelete("{versionId:guid}")]
        public async Task<IActionResult> Delete(Guid actId, Guid versionId)
        {
            await service.DeleteAsync(actId, versionId);
            return NoContent();
        }
    }
}
