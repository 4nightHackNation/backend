using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SciezkaPrawa.Application.Auth;
using SciezkaPrawa.Application.User.DTOs;
using SciezkaPrawa.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Infrastructure
{
    public class AuthService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
        ) : IAuthService
    {
        public async Task CreateUserAsync(CreateUserDto dto)
        {

            var existing = await userManager.FindByNameAsync(dto.UserName);
            if (existing != null)
            {
                throw new InvalidOperationException($"Użytkownik '{dto.UserName}' już istnieje.");
            }

            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Nie udało się utworzyć użytkownika: {errors}");
            }

            var role = string.IsNullOrWhiteSpace(dto.Role) ? "User" : dto.Role;
            var roleResult = await userManager.AddToRoleAsync(user, role);

            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Nie udało się przypisać roli '{role}': {errors}");
            }
        }

        public async Task ResetPasswordAsync(string userName, string newPassword)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return;
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
            {
                return;
            }
        }

        public async Task DeleteUserAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userName);
            }

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Nie udało się usunąć użytkownika: {errors}");
            }
        }

        public async Task<bool> LoginAsync(LoginDto login, HttpContext httpContext)
        {
            var user = await userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                return false;
            }

            // sprawdzenie hasła
            if (!await userManager.CheckPasswordAsync(user, login.Password))
            {
                return false;
            }

            var props = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await httpContext.SignInAsync(
                IdentityConstants.ApplicationScheme,
                await signInManager.CreateUserPrincipalAsync(user),
                props);

            return true;
        }

        public async Task LogoutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        }
    }
}
