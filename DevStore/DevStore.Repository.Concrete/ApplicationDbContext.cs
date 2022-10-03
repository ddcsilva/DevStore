using DevStore.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Repository.Concrete
{
    // Classe para acesso ao Banco de Dados
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Carrega todas as definições que estão no assembly da classe especificada
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityMap).Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
