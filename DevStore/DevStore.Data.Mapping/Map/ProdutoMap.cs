using DevStore.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Data.Mapping
{
    public class ProdutoMap : BaseEntityMap<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();

            builder.Property(p => p.IdCategoria).IsRequired();
            builder.HasOne(p => p.Categoria).WithMany().HasForeignKey(c => c.IdCategoria);

            builder.Property(p => p.IdLoja).IsRequired();
            builder.HasOne(p => p.Loja).WithMany().HasForeignKey(l => l.IdLoja);
        }
    }
}
