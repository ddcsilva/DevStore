using DevStore.Data.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Data.Mapping
{
    public class CategoriaProdutoMap : BaseEntityMap<CategoriaProduto>
    {
        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
        }
    }
}
