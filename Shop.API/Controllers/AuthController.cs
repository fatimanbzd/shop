using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Identity.Login;
using Shop.Application.Features.Identity.Register;
using Shop.Application.Shared.Interfaces;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpPost("login")]
        public async Task<IActionResult> logIn(LoginCommand command, CancellationToken cancellationToken)
        {

            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
                return Unauthorized(result.Error);

            return Ok(result.Value);

        }

    }
}
