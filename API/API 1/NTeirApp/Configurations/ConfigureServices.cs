using NTeirApp.Business.Services.Abstractions;
using NTeirApp.Business.Services.Interfaces;
using NTeirApp.Dal.Repositories.Abstractions;
using NTeirApp.Dal.Repositories.Interfaces;
using NTierApp.Business.Services.Abstractions;
using NTierApp.Business.Services.Interfaces;
using NTierApp.Dal.Repositories.Abstractions;
using NTierApp.Dal.Repositories.Interfaces;

namespace NTierApp.Api.Configurations
{
    public static class ConfigureServices
    {
        public static void AddConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICarService, CarService>();
        }
    }
}
