using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Application.Commands;
using Torino.Application.DTOs;

namespace Torino.Application.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterCommand command);

        Task<AuthResponseDto> LoginAsync(LoginCommand command);
    }
}
