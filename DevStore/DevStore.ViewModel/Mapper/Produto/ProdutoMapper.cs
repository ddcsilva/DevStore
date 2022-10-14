using DevStore.Common.Extensions;
using DevStore.Data.Domain;

namespace DevStore.ViewModel
{
    public static class ProdutoMapper
    {
        public static List<ProdutoViewModel> ToViewModel(this List<Produto> fromList)
        {
            var to = new List<ProdutoViewModel>();

            foreach (var item in fromList)
            {
                to.Add(item.ToViewModel());
            }

            return to;
        }

        public static ProdutoViewModel ToViewModel(this Produto from)
        {
            var slug = from.Nome.GetSlug();

            var imagemPrincipal = "";
            if (from.Imagens != null && from.Imagens.Count > 0)
            {
                var principal = from.Imagens.Find(x => x.Principal);
                if (principal != null)
                {
                    imagemPrincipal = principal.NomeArquivo;
                }
            }

            var to = new ProdutoViewModel { Nome = from.Nome, Descricao = from.Descricao, Slug = slug, Preco = from.Preco, ImagemPrincipal = imagemPrincipal };
            return to;
        }
    }
}
