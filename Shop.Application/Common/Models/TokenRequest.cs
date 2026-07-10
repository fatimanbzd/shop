using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Models
{
    public sealed record TokenRequest(
    Guid UserId,
    string Email,
    IReadOnlyCollection<string> Roles);
}
