using DevStore.Repository.Concrete;
using DevStore.Repository.Interface;

namespace DevStore.WebApp.Configuration
{
    public static class DiRepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
        }
    }
}
