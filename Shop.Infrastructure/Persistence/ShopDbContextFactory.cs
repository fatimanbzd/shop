using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistence
{
    public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            var path = Path.Combine(
            Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
            "Shop.Api"
        );
            var configuration = new ConfigurationBuilder()
          .SetBasePath(path)
          .AddJsonFile("appsettings.json")
          .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("ShopConnection"));

            return new ShopDbContext(optionsBuilder.Options);
        }
    }
}
