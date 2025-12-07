using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Acts;
using SciezkaPrawa.Application.Auth;
using SciezkaPrawa.Application.User.DTOs;

namespace SciezkaPrawa.API.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
        {
            dto.Role = null;

            await authService.CreateUserAsync(dto);

            return Ok("Konto użytkownika zostało utworzone.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var result = await authService.LoginAsync(login, HttpContext);

            if (!result)
            {
                return Unauthorized();
            }

            return Ok();

        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync(HttpContext);
            return Ok();
        }
    }
}

