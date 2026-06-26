using Shop.Application.Core.Services;
using Shop.Domain.Core.Repositories;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Repositpries;
using Shop.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:ShopConnection",
                x => x.MigrationsAssembly("Shop.Infrastructure")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void MigrateDatabase(this IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<ShopDbContext>>();

            using (var dbContext = new ShopDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
