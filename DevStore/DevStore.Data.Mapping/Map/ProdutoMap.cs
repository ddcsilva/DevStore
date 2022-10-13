using DevStore.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DevStore.Data.Mapping
{
    public class ProdutoMap : BaseEntityMap<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Preco).HasPrecision(7, 2).IsRequired();

            builder.Property(p => p.QuantidadeEstoque).HasPrecision(4).IsRequired();
            builder.Property(p => p.Garantia).HasPrecision(4).IsRequired();
            builder.Property(p => p.TipoGarantia).IsRequired();

            builder.Property(p => p.IdCategoria).IsRequired();
            builder.HasOne(p => p.Categoria).WithMany().HasForeignKey(c => c.IdCategoria);

            builder.Property(p => p.IdLoja).IsRequired();
            builder.HasOne(p => p.Loja).WithMany().HasForeignKey(l => l.IdLoja);

            builder.Property(p => p.Imagens).HasConversion(
                i => JsonConvert.SerializeObject(i, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                i => JsonConvert.DeserializeObject<List<ImagemProduto>>(i, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
