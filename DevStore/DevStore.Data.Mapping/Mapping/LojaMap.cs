using DevStore.Data.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevStore.Data.Mapping.Mapping
{
    public class LojaMap : BaseEntityMap<Loja>
    {
        public override void Configure(EntityTypeBuilder<Loja> builder)
        {
            base.Configure(builder);

            builder.Property(l => l.Nome).HasMaxLength(100).IsRequired();
        }
    }
}
