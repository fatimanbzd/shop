using Shop.Application.Common.Models;
using Shop.Application.Common.Results;

namespace Shop.Application.Shared.Interfaces
{
    public interface ITokenService
    {

        Task<Result<TokenResponse>> GenerateTokenAsync(
                Guid identityUserId,
                CancellationToken cancellationToken);
    }
}
