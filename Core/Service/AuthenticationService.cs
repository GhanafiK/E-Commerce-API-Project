using DomainLayer.Exceptions;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager) : IAuthenticationService
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
                    Token = GetTokenAsync(user)
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
                    Token = GetTokenAsync(User)
                };
            else
            {
                var Errors=Result.Errors.Select(E=>E.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }

        private static string GetTokenAsync(ApplicationUser user)
        {
            return "To-Do-Token";
        }
    }
}
