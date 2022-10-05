using DevStore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevStore.Data.Mapping
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private const string _projectName = "DevStore.WebApp";
        private const string _configFileName = "appsettings.Development.json";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var diretorioBase = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.FullName;
            var path = Path.Combine(diretorioBase, _projectName, _configFileName);

            var configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
            var connectionString = configuration.GetConnectionString(AppConfiguration.ConnectionStringTag);

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
