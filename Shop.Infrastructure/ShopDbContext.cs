using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shop.Infrastructure
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
    }
}
