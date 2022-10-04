using DevStore.Data.Mapping;
using DevStore.Repository.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DevStore.WebApp.Configuration
{
    public static class EntityFrameworkExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Principal");
                options.UseSqlServer(connectionString, option => option.MigrationsAssembly(typeof(BaseEntityMap<>).Assembly.FullName));
            });
        }
    }
}
