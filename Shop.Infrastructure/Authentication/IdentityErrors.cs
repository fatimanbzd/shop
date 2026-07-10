using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Authentication
{
    public static class IdentityErrors
    {
        public static Error CreateUserFailed(string description) =>
            new("Identity.CreateUserFailed", description);

        public static readonly Error UserNotFound =
            new("Identity.UserNotFound", "Identity user was not found.");

        public static Error AddToRoleFailed(string description) =>
            new("Identity.AddRoleFailed", description);
    }
}
