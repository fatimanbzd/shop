using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Shop.Application.Common.Models;
using Shop.Application.Common.Results;
using Shop.Application.Shared.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Authentication
{
    public class TokenService: ITokenService
    {
        public Task<Result<TokenResponse>> GenerateTokenAsync(Guid identityUserId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var now = DateTime.UtcNow;
            // Generate JWT token
            var tokenResponse = new TokenResponse(
            AccessToken: $"dev-access-{identityUserId:N}-{Guid.NewGuid():N}",
            RefreshToken: $"dev-refresh-{Guid.NewGuid():N}",
            AccessTokenExpiresAt: now.AddMinutes(15),
            RefreshTokenExpiresAt: now.AddDays(7)
        );

            return Task.FromResult(Result<TokenResponse>.Success(tokenResponse));

        }
    }
}
