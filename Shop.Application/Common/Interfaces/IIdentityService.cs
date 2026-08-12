using Shop.Application.Common.Results;
using Shop.Application.Features.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Shared.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<bool> IsMobileExistsAsync(string mobile, CancellationToken cancellationToken);
        Task<Result<Guid>> CreateUserAsync(
       CreateIdentityUserRequest request,
         CancellationToken cancellationToken);

        Task<Result> AddToRoleAsync(
       Guid identityUserId,
       string role,
       CancellationToken cancellationToken);

        Task<Result> DeleteUserAsync(
      Guid identityUserId,
      CancellationToken cancellationToken);
    }
}
