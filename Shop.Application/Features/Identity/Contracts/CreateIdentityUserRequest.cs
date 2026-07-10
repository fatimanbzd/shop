using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity.Models
{
    public sealed record CreateIdentityUserRequest(
      Guid DomainUserId,
      string Email,
      string Mobile,
      string Password);
}
