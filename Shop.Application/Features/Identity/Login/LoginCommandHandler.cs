using MediatR;
using Shop.Application.Common.Results;
using Shop.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity.Login
{
    public sealed class LoginCommandHandler
        : IRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(
        IIdentityService identityService,
        ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponse>> Handle(
      LoginCommand request,
      CancellationToken cancellationToken)
        {
            var identityResult =
           await _identityService.ValidateCredentialsAsync(
               request.Email,
               request.Password,
               cancellationToken);


            if (identityResult.IsFailure)
            {
                return Result<LoginResponse>.Failure(
                    identityResult.Error);
            }

            var tokenResult =
            await _tokenService.GenerateTokenAsync(
                identityResult.Value,
                cancellationToken);

            if (tokenResult.IsFailure)
            {
                return Result<LoginResponse>.Failure(
                    tokenResult.Error);
            }
            return Result<LoginResponse>.Success(
      new LoginResponse(
          identityResult.Value,
          tokenResult.Value.AccessToken,
          tokenResult.Value.RefreshToken));
        }
    }
}
