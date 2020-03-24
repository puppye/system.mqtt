using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace System.Auth
{
    public static class AuthServiceLoader
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlite(connectionString));
            // services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AuthDbContext>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            // return services
            return services;
        }
    }
}
