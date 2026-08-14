using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Features.Identity.Login
{
    public sealed record LoginResponse(
   Guid UserId,
   string AccessToken,
   string RefreshToken
);
}
