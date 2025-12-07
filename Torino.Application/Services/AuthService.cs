using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Text;
using Torino.Application.Commands;
using Torino.Application.DTOs;
using Torino.Application.Interfaces;
using Torino.Domain.Entities;

namespace Torino.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Register request cannot be null");

            var existingUser = await _userManager.FindByEmailAsync(command.Email);

            if (existingUser != null)
                throw new Exception("email belongs to another user");

            var user = new ApplicationUser(
                 command.Email,           
                 command.Email,           
                 command.Fullname,        
                 command.Name,            
                 command.UserRole,        
                 command.Brithdate,       
                 command.Passport,        
                 command.PassportNumber,  
                 command.PassportExpiryDate, 
                 command.NationalCode,    
                 command.CardNumber,      
                 command.IBAN             
             );


            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new Exception(errors);
            }
            await _userManager.AddToRoleAsync(user, command.UserRole.ToString());

            return result;

        }


        public async Task<AuthResponseDto> LoginAsync(LoginCommand command)
        {

            if (command == null)
                throw new ArgumentNullException("Login request cannot be null.");

            var user = await _userManager.FindByEmailAsync(command.Email);

            if (user == null)
                throw new Exception("Invalid email or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, command.Password, false);

            if (!result.Succeeded)
                throw new Exception("Invalid email or password.");

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.UserRole.ToString(),
                Expiration = DateTime.UtcNow.AddHours(3)
            };
        }


        private string GenerateJwtToken(ApplicationUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("userId", user.Id),
                new Claim("role", user.UserRole.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
