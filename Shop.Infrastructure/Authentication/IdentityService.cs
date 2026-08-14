using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Results;
using Shop.Application.Features.Identity;
using Shop.Application.Features.Identity.Models;
using Shop.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Infrastructure.Authentication
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> IsEmailExistsAsync(
    string email,
    CancellationToken cancellationToken)
        {
            return await _userManager.Users
                .AnyAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<bool> IsMobileExistsAsync(
    string mobile,
    CancellationToken cancellationToken)
        {
            return await _userManager.Users
                .AnyAsync(x => x.PhoneNumber == mobile, cancellationToken);
        }

        public async Task<Result<Guid>> CreateUserAsync(
    CreateIdentityUserRequest request,
    CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                DomainUserId = request.DomainUserId,
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.Mobile,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    Environment.NewLine,
                    result.Errors.Select(x => x.Description));

                return Result<Guid>.Failure(
    IdentityErrors.CreateUserFailed(errors));
            }

            return Result<Guid>.Success(user.Id);
        }

        public async Task<Result> AddToRoleAsync(
    Guid identityUserId,
    string role,
    CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(identityUserId.ToString());

            if (user is null)
            {
                return Result.Failure(
    IdentityErrors.UserNotFound);
            }

            var result = await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    Environment.NewLine,
                    result.Errors.Select(x => x.Description));

                Result.Failure(
     IdentityErrors.AddToRoleFailed(errors));
            }

            return Result.Success();
        }


        public async Task<Result> DeleteUserAsync(
        Guid identityUserId,
        CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(identityUserId.ToString());

            if (user is null)
            {
                return Result.Success();
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                // Error واقعی پروژهٔ خودت را برگردان
                return Result.Failure(UserErrors.DeleteFailed);
            }

            return Result.Success();
        }
<<<<<<< HEAD


        public async Task<Result<Guid>> ValidateCredentialsAsync(
    string email,
    string password,
    CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return Result<Guid>.Failure(
                    IdentityErrors.InvalidCredentials);
            }


            var validPassword =
        await _userManager.CheckPasswordAsync(user, password);

            if (!validPassword)
            {
                return Result<Guid>.Failure(
                    IdentityErrors.InvalidCredentials);
            }

            return Result<Guid>.Success(user.Id);

        }
=======
>>>>>>> main
    }
}
