using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Authentication
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid DomainUserId { get; set; }
    }
}
