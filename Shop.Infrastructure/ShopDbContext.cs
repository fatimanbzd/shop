using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Shared.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Authentication;

namespace Shop.Infrastructure
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();

        public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
