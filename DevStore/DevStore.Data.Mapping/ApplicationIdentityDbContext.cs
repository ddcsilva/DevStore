using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Data.Mapping
{
    // Integrando o Identity ao Entity Framework
    public class ApplicationIdentityDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int,
        IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Carrega todas as definições que estão no assembly da classe especificada
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityUser<>).Assembly);

            modelBuilder.AddSnakeCase(true);
        }

        public ApplicationIdentityDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
