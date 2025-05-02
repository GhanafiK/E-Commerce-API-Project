using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AuthenticationController(IServiceManager _serviceManager):ApiBaseController
    {
        //login
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var User=await _serviceManager.AuthenticationService.LoginAsync(loginDto);
            return Ok(User);
        }

        //Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var User=await _serviceManager.AuthenticationService.RegisterAsync(registerDto);
            return Ok(User);
        }

        //Check Email
        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string Email)
        {
            var Result=await _serviceManager.AuthenticationService.CheckEmailAsync(Email);
            return Ok(Result);
        }

        // Get Current User
        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email=User.FindFirstValue(ClaimTypes.Email);
            var AppUser= await _serviceManager.AuthenticationService.GetCurrentUserAsync(email!);
            return Ok(AppUser);
        }

        // Get Current User Address
        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var Address=await _serviceManager.AuthenticationService.GetCurrentUserAddressAsync(email!);
            return Ok(Address);
        }

        // Update Current User Address
        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateCurrentUserAddress(AddressDto addressDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var UpdatedAddress = await _serviceManager.AuthenticationService.UpdateCurrentUserAddressAsync(email,addressDto);
            return Ok(UpdatedAddress);
        }
    }
}
