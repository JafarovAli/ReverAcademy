using Garage.Data;
using Microsoft.EntityFrameworkCore;

namespace Garage.Configurations
{
    public static class DBConfigure
    {
        public static void AddDBConfigure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Garage"));
            });
        }
    }
}
