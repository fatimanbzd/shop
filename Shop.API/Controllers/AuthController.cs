using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Shop.Application.Features.Identity.Login;
using Shop.Application.Features.Identity.Shared.Interfaces;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> logIn(LoginResponse loginModel)
        //{
        //    try
        //    {
                //var user = _authService.LogIn(loginModel.email, loginModel.password);
                //if (user == null)
                //{

                //    return BadRequest(ApiResponse.Error("User not found!"));
                //}
                //return await Task.FromResult<IActionResult>(Ok(ApiResponse.Success(new LoginResponse
                //{
                //    FirstName = user.Result.FirstName,
                //    LastName = user.Result.LastName,
                //    Phone = user.Result.Phone,
                //    Token = user.Result.Token
                //})));
            //    return null;
            //}
            //catch (Exception ex)
            //{
               // return BadRequest(ApiResponse.Error(ex.Message));
        //    }
        //}

        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register(User userDto)
        //{
        //    try
        //    {
        //        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        //        string saltBase64 = Convert.ToBase64String(salt);

        //        User user = new User(
        //            userDto.Email,
        //            password: userDto.Password,
        //            saltBase64,
        //            userDto.FirstName,
        //            userDto.LastName,
        //            userDto.Phone,
        //            EnumUserType.Customer

        //        );

        //        await _authService.Register(userDto);
        //        return Ok(ApiResponse.Success("Register is Succeed."));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ApiResponse.Error(ex.Message));

        //    }

        //}
    }
}
