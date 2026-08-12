using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Shared.Interfaces;
using Shop.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ShopConnection")));

            services.AddIdentityCore<ApplicationUser>()
.AddRoles<ApplicationRole>()
.AddEntityFrameworkStores<ShopDbContext>()
.AddDefaultTokenProviders();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IApplicationDbContext>(sp =>
    sp.GetRequiredService<ShopDbContext>());
            return services;

        }
    }
}
