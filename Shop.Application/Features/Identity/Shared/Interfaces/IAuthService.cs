using Shop.Application.Features.Identity.Login;
using Shop.Application.Features.Identity.RefreshToken;
using Shop.Application.Features.Identity.Register;

namespace Shop.Application.Features.Identity.Shared.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginResponse request);
       // Task<AuthResponseDto> RegisterAsync(RegisterResponse request);
    }
}
