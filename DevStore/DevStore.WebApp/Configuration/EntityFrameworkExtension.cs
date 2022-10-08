using DevStore.Common;
using DevStore.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DevStore.WebApp.Configuration
{
    public static class EntityFrameworkExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(AppConfiguration.ConnectionStringTag);

            // Contexto principal do Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, option => option.MigrationsAssembly(typeof(BaseEntityMap<>).Assembly.FullName));
            });

            // Contexto Identity do entity framework
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName));
            });
        }
    }
}
