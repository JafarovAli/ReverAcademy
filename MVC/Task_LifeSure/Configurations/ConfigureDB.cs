using Microsoft.EntityFrameworkCore;
using Task_LifeSure.Data;

namespace Task_LifeSure.Configurations
{
    public static class ConfigureDB
    {
        public static void AddDB(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LifeSure"))
            );
        }
    }
}
