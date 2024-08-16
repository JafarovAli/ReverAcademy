using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTeirApp.Dal.Repositories.Abstractions;
using NTeirApp.Dal.Repositories.Interfaces;
using NTierApp.Core.Common;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Abstractions;
using NTierApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Dal
{
    public static class DALDependencyInjection
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDBContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("Default"));
            //}
            //);

            var connectionString = Environment.GetEnvironmentVariable("Default")
                                           ?? configuration.GetConnectionString("Default");

            services.AddDbContext<AppDBContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));
        }

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

        public static void AddRepsitories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
        }
    }
}
