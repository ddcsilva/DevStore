namespace DevStore.Data.Domain.Entity
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public virtual CategoriaProduto Categoria { get; set; }
        public int IdCategoria { get; set; }
    }
}
