using Shop.Application.Models.DTOs.UserDto;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
