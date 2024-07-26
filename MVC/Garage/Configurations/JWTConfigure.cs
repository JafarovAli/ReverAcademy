using Garage.Data;
using Garage.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Garage.Configurations
{
    public static class JWTConfigure
    {
        public static void AddIdentityUser(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(
                option =>
                {
                    option.Password.RequiredLength = 8;
                    option.Password.RequireDigit = true;
                    option.Password.RequireLowercase = true;
                    option.Password.RequireUppercase = true;
                }
                ).AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();
        }
    }
}
