using DomainLayer.Exceptions;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager,IConfiguration _configuration) : IAuthenticationService
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user=await _userManager.FindByEmailAsync(loginDto.Email)??throw new UserNotFoundException(loginDto.Email);
            var IsPasswordValid=await _userManager.CheckPasswordAsync(user,loginDto.Password);
            if (IsPasswordValid)
                return new UserDto()
                {
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    Token =await GetTokenAsync(user)
                };
            else
                throw new UnAuthenticatedException();

        }

        

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            // mapping registerDTO to ApplicationUSer
            var User = new ApplicationUser()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName,
            };

            var Result=await _userManager.CreateAsync(User,registerDto.Password);

            if (Result.Succeeded)
                return new UserDto()
                {
                    Email = User.Email,
                    DisplayName = User.DisplayName,
                    Token =await GetTokenAsync(User)
                };
            else
            {
                var Errors=Result.Errors.Select(E=>E.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }

        private async Task<string> GetTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new(ClaimTypes.Email,user.Email!),
                new(ClaimTypes.Name,user.UserName!),
                new(ClaimTypes.NameIdentifier,user.Id!),
            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach(var role in  Roles)
                Claims.Add(new Claim(ClaimTypes.Role, role));

            var SecretKey = _configuration.GetSection("JWTOptions")["SecretKey"];
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                issuer: _configuration.GetSection("JWTOptions")["Issuer"],
                audience: _configuration.GetSection("JWTOptions")["Audience"],
                claims: Claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
