using Shared.DataTransfareObjects.IdentitiyModuleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IAuthenticationService
    {
        //login
        Task<UserDto> LoginAsync(LoginDto loginDto);

        //register
        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        //check email
        Task<bool> CheckEmailAsync(string Email);

        //Get Current User Address
        Task<AddressDto> GetCurrentUserAddressAsync(string Email);

        //Update Current User Address
        Task<AddressDto> UpdateCurrentUserAddressAsync(string Email,AddressDto addressDto);

        //Get Current User
        Task<UserDto> GetCurrentUserAsync(string Email);



    }
}
