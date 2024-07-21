using Microsoft.AspNetCore.Identity;
using Task_MVC3.Data;
using Task_MVC3.Models;

namespace Task_MVC3.Configurations
{
    public static class ConfigureJWT
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
                ).AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();
        }
    }
}
