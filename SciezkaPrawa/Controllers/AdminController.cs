using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SciezkaPrawa.Application.Auth;
using SciezkaPrawa.Application.User.DTOs;

namespace SciezkaPrawa.API.Controllers
{
    [Route("/api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController(IAuthService authService) : ControllerBase
    {
        [HttpPost("create-officer-account")]
        public async Task<IActionResult> CreateOfficer([FromBody] CreateUserDto dto)
        {
            dto.Role = "Officier"; // 🔥 wymuszamy rolę urzędnika

            await authService.CreateUserAsync(dto);

            return Ok("Utworzono konto urzędnika.");

        }

        [HttpDelete("delete-officer-account/{username}")]
        public async Task<IActionResult> DeleteOfficer(string username)
        {
            await authService.DeleteUserAsync(username);
            return Ok("Usunięto konto urzędnika.");
        }
    }
}
