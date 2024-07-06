using Microsoft.EntityFrameworkCore;
using Task_MVC3.Data;

namespace Task_MVC3.Configurations
{
    public static class DBConfigure
    {
        public static void AddDBConfigure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Shops"))
            );
        }
    }
}
