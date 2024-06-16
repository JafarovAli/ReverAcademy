using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.Configurations
{
    public static class ConfigureDB
    {
        public static void AddConfigureDbServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetSection("ConnectionStrings:Car").Value)
            );
		}
	}
}
