using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Identity.Login;
using Shop.Application.Features.Identity.Register;
using Shop.Application.Shared.Interfaces;
using System.Reflection;
using System.Security.Cryptography;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
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
