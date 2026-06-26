using Shop.Application.Interfaces;
using Shop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            
        }
    }
}
