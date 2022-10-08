using DevStore.Common.Extensions;
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

            modelBuilder.AddSnakeCase(false);
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => (e.Entity is BaseEntity) && (e.State == EntityState.Added));

            // Preenche o campo CreatedAt com a data+hora quando a entidade está sendo incluída
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    var entity = (BaseEntity)entityEntry.Entity;
                    entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
