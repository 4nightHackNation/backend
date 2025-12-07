using Microsoft.AspNetCore.Http;
using SciezkaPrawa.Application.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Auth
{
    public interface IAuthService
    {
        Task CreateUserAsync(CreateUserDto dto);
        Task ResetPasswordAsync(string userName, string newPassword);
        Task DeleteUserAsync(string userName);
        Task<bool> LoginAsync(LoginDto login, HttpContext httpContext);
        Task LogoutAsync(HttpContext httpContext);
    }
}
