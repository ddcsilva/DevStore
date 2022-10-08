using DevStore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevStore.Data.Mapping
{
    public class BaseDesignTimeDbContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        private const string _projectName = "DevStore.WebApp";
        private const string _configFileName = "appsettings.Development.json";

        public TDbContext CreateDbContext(string[] args)
        {
            var diretorioBase = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.FullName;
            var path = Path.Combine(diretorioBase, _projectName, _configFileName);

            var configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
            var connectionString = configuration.GetConnectionString(AppConfiguration.ConnectionStringTag);

            var builder = new DbContextOptionsBuilder<TDbContext>();
            builder.UseSqlServer(connectionString);

            return (TDbContext)Activator.CreateInstance(typeof(TDbContext), new object[] { builder.Options });
        }
    }
}