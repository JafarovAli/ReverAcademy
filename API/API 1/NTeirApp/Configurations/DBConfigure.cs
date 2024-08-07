using Microsoft.EntityFrameworkCore;
using NTierApp.Dal.Context;
using System;

namespace NTierApp.Api.Configurations
{
    public static class DBConfigure
    {
        public static void AddDBConfigure(this IServiceCollection services,
                                          IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            }
            );
        }
    }
}
