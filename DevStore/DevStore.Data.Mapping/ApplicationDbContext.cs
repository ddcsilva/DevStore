using DevStore.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Data.Mapping
{
    // Classe para acesso ao Banco de Dados
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Carrega todas as definições que estão no assembly da classe especificada
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityMap<>).Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Loja> Lojas { get; set; }
        public DbSet<CategoriaProduto> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
