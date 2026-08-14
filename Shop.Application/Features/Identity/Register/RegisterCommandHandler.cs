using MediatR;
using Shop.Application.Common.Results;
using Shop.Application.Features.Identity.Models;
using Shop.Application.Shared.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Identity.Register
{
    public sealed class RegisterCommandHandler
     : IRequestHandler<RegisterCommand, Result<RegisterResponse>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(
            IApplicationDbContext context,
            IIdentityService identityService,
            ITokenService tokenService)
        {
            _context = context;
            _identityService = identityService;
            _tokenService = tokenService;
        }


        public async Task<Result<RegisterResponse>> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {

            if (await _identityService.IsEmailExistsAsync(
         request.Email,
         cancellationToken))
            {
                return Result<RegisterResponse>.Failure(
                    UserErrors.EmailAlreadyExists);
            }

            if (await _identityService.IsMobileExistsAsync(
                    request.Mobile,
                    cancellationToken))
            {
                return Result<RegisterResponse>.Failure(
                    UserErrors.MobileAlreadyExists);
            }

            var user = User.CreateCustomer(
      request.FirstName,
      request.LastName,
      request.Email,
      request.Mobile);

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            // Create Identity User
            var identityResult = await _identityService.CreateUserAsync(
                new CreateIdentityUserRequest(
                    user.Id,
                    user.Email,
                    user.Mobile,
                    request.Password),
                cancellationToken);

            if (identityResult.IsFailure)
            {
                await RemoveApplicationUserAsync(user, cancellationToken);

                return Result<RegisterResponse>.Failure(identityResult.Error);
            }

            var roleResult = await _identityService.AddToRoleAsync(
           identityResult.Value,
           Roles.Customer,
           cancellationToken);

            if (roleResult.IsFailure)
            {
                return Result<RegisterResponse>.Failure(roleResult.Error);
            }
            var tokenResult = await _tokenService.GenerateTokenAsync(
       identityResult.Value,
       cancellationToken);

            if (tokenResult.IsFailure)
            {
                return Result<RegisterResponse>.Failure(tokenResult.Error);
            }

            return Result<RegisterResponse>.Success(
        new RegisterResponse(
            identityResult.Value,
            tokenResult.Value.AccessToken,
            tokenResult.Value.RefreshToken));


            throw new NotImplementedException();
        }

        private async Task RemoveApplicationUserAsync(
    User user,
    CancellationToken cancellationToken)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
