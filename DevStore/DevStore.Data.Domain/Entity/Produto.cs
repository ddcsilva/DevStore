namespace DevStore.Data.Domain
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }

        public int Garantia { get; set; }
        public TipoGarantiaEnum TipoGarantia { get; set; }

        public virtual CategoriaProduto Categoria { get; set; }
        public int IdCategoria { get; set; }

        public virtual Loja Loja { get; set; }
        public int IdLoja { get; set; }

        public virtual List<ImagemProduto> Imagens { get; set; }
    }
}
