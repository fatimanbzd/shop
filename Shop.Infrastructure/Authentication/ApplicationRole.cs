using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Authentication
{
    public class ApplicationRole: IdentityRole<Guid>
    {
    }
}
