using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity
{
    public class UserErrors
    {
        public static readonly Error EmailAlreadyExists =
        new("User.EmailAlreadyExists", "Email already exists.");

        public static readonly Error MobileAlreadyExists =
            new("User.MobileAlreadyExists", "Mobile already exists.");

        public static readonly Error InvalidCredentials =
            new("User.InvalidCredentials", "Invalid email or password.");

        public static readonly Error UserNotFound =
            new("User.NotFound", "User not found.");
    }
}
