using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Identity
{
    public static class Roles
    {
        public const string Customer = nameof(Customer);
        public const string Seller = nameof(Seller);
        public const string Admin = nameof(Admin);
    }
}
