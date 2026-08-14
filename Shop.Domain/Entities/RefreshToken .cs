using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    internal class RefreshToken
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string TokenHash { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTimeOffset RevokedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
