using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.AiClient;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/acts/{actId:guid}")]
    public class ActExplanationController(IActExplanationService explanationService) : ControllerBase
    {
        // POST /api/acts/{actId}/explanation
        [HttpPost("explanation")]
        public async Task<ActionResult<string>> GenerateExplanation(Guid actId, [FromQuery] Guid? versionId = null)
        {
            var explanation = await explanationService.GeneratePlainLanguageExplanationAsync(actId, versionId);
            return Ok(explanation);
        }
    }
}
