using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torino.Application.Commands;
using Torino.Application.Interfaces;
using Torino.WebApi.Controllers;

namespace Torino.Controllers
{
    public class AuthController : TourinoBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            try
            {
                var result = await _authService.RegisterAsync(command);
                if (result.Succeeded)
                    return Respond(StatusCodes.Status201Created, message: "ثبت‌نام با موفقیت انجام شد");

                var errors = result.Errors.Select(e => e.Description).ToList();
                return Respond(StatusCodes.Status400BadRequest, errors: errors);
            }
            catch (Exception ex)
            {
                return Respond(StatusCodes.Status400BadRequest, message: ex.Message);
            }
        }

        
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                var response = await _authService.LoginAsync(command);
                return Respond(StatusCodes.Status200OK, data: response, message: "ورود موفقیت‌آمیز");
            }
            catch (Exception ex)
            {
                return Respond(StatusCodes.Status400BadRequest, message: ex.Message);
            }
        }
    }
    
}
