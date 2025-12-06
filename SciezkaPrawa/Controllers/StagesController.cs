using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Acts;
using SciezkaPrawa.Application.Acts.DTOs;
using SciezkaPrawa.Application.Stages;
using SciezkaPrawa.Application.Stages.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Infrastructure.Repositories;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/acts/{actId:guid}/stages")]
    public class ActStagesController(IActStagesService stageService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ActStage>> Create(Guid actId, [FromBody] SaveActStageDto dto)
        {
            var created = await stageService.CreateAsync(actId, dto);

            return CreatedAtAction(
                nameof(Create),
                new { actId, stageId = created.Id },
                created);
        }

        [HttpPut("{stageId:guid}")]
        public async Task<IActionResult> Update(Guid actId, Guid stageId, [FromBody] SaveActStageDto dto)
        {
            await stageService.UpdateAsync(actId, stageId, dto);
            return NoContent();
        }

        [HttpDelete("{stageId:guid}")]
        public async Task<IActionResult> Delete(Guid actId, Guid stageId)
        {
            await stageService.DeleteAsync(actId, stageId);
            return NoContent();
        }
    }
}
