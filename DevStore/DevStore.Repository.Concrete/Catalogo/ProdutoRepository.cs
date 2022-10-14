using DevStore.Data.Domain;
using DevStore.Data.Mapping;
using DevStore.Repository.Interface.Catalogo;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Repository.Concrete
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _dbContext;

        public ProdutoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }
}
