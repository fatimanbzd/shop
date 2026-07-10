using Shop.Application.Features.Identity.Login;
using Shop.Application.Features.Identity.RefreshToken;
using Shop.Application.Features.Identity.Register;

namespace Shop.Application.Shared.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginResponse request);
       // Task<AuthResponseDto> RegisterAsync(RegisterResponse request);
    }
}
