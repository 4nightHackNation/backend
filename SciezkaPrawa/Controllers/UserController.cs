using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.User;

namespace SciezkaPrawa.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "User,Official")]
    public class FollowingController(IUserFollowingService service) : ControllerBase
    {
        [HttpPost("follow/{actId:guid}")]
        public async Task<IActionResult> Follow(Guid actId)
        {
            var username = User.Identity!.Name!;
            await service.FollowAsync(username, actId);
            return Ok("Act followed");
        }

        [HttpDelete("follow/{actId:guid}")]
        public async Task<IActionResult> Unfollow(Guid actId)
        {
            var username = User.Identity!.Name!;
            await service.UnfollowAsync(username, actId);
            return Ok("Act unfollowed");
        }

        [HttpGet("followed-acts")]
        public async Task<IActionResult> GetFollowed()
        {
            var username = User.Identity!.Name!;
            var acts = await service.GetFollowedActsAsync(username);
            return Ok(acts);
        }
    }
}
