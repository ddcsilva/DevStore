using DevStore.Common;
using DevStore.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DevStore.WebApp.Configuration
{
    public static class EntityFrameworkExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(AppConfiguration.ConnectionStringTag);
                options.UseSqlServer(connectionString, option => option.MigrationsAssembly(typeof(BaseEntityMap<>).Assembly.FullName));
            });
        }
    }
}
