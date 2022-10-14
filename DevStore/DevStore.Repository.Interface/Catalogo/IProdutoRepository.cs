using DevStore.Data.Domain;

namespace DevStore.Repository.Interface.Catalogo
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutos();
    }
}
