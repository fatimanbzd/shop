using MediatR;
using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity.Login
{
    public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<LoginResponse>>;
}
