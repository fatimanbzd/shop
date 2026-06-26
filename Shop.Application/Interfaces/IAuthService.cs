using Shop.Application.Models.DTOs.UserDto;
using Shop.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LogIn(string emil, string password);

        Task Register(UserDto userDto);
    }
}
