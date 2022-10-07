using DevStore.Data.Domain;
using DevStore.Data.Mapping;
using DevStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Repository.Concrete
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        private ApplicationDbContext _context;

        public CategoriaProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaProduto>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
