using DevStore.Repository.Concrete;
using DevStore.Repository.Interface;
using DevStore.Repository.Interface.Catalogo;

namespace DevStore.WebApp.Configuration
{
    public static class DiRepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
