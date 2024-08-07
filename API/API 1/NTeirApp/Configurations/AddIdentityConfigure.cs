using Microsoft.AspNetCore.Identity;
using NTierApp.Core.Common;
using NTierApp.Dal.Context;

namespace NTierApp.Api.Configurations
{
    public static class AddIdentityConfigure
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
