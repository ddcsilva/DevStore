using DevStore.Data.Domain;

namespace DevStore.Repository.Interface
{
    public interface ICategoriaProdutoRepository
    {
        Task<List<CategoriaProduto>> GetCategorias();
    }
}
