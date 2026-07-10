using MediatR;
using Shop.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity.Register
{
    public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,   
    string Mobile,
    string Password
) : IRequest<Result<RegisterResponse>>;
}
