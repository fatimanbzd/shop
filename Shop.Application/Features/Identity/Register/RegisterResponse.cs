using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity.Register
{
    public sealed record RegisterResponse(
     Guid UserId,
     string AccessToken,
     string RefreshToken
 );
}
