using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Shop.Application.Common.Models;
using Shop.Application.Common.Results;
using Shop.Application.Shared.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Authentication
{
    public class TokenService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public TokenService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<Result<TokenResponse>> GenerateTokenAsync(Guid identityUserId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(
            identityUserId.ToString());


            if (user is null)
            {
                return Result<TokenResponse>.Failure(
                    IdentityErrors.UserNotFound);
            }
            var roles = await _userManager.GetRolesAsync(user);

            var now = DateTimeOffset.UtcNow;

            var accessTokenExpiresAt =
                now.AddMinutes(_jwtOptions.AccessTokenExpirationMinutes);

            var refreshTokenExpiresAt =
                now.AddDays(_jwtOptions.RefreshTokenExpirationDays);

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            claims.AddRange(
           roles.Select(role =>
               new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
           issuer: _jwtOptions.Issuer,
           audience: _jwtOptions.Audience,
           claims: claims,
           notBefore: now.UtcDateTime,
           expires: accessTokenExpiresAt.UtcDateTime,
           signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler()
                .WriteToken(jwtToken);

            var refreshToken = GenerateRefreshToken();

            return Result<TokenResponse>.Success(
           new TokenResponse(
               accessToken,
               refreshToken,
               accessTokenExpiresAt,
               refreshTokenExpiresAt));
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(
                RandomNumberGenerator.GetBytes(64));
        }
    }
}
