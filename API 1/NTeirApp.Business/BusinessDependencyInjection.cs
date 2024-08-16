using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTeirApp.Business.Services.Abstractions;
using NTeirApp.Business.Services.Interfaces;
using NTeirApp.Dal.Repositories.Abstractions;
using NTeirApp.Dal.Repositories.Interfaces;
using NTierApp.Business.Services.Abstractions;
using NTierApp.Business.Services.Interfaces;
using NTierApp.Dal.Repositories.Abstractions;
using NTierApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business
{
    public static class BusinessDependencyInjection
    {
        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
