using DevStore.Repository.Interface;
using DevStore.Repository.Interface.Catalogo;
using DevStore.ViewModel;
using DevStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevStore.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoriaProdutoRepository categoriaProdutoRepository;
        private readonly IProdutoRepository produtoRepository;

        public HomeController(ICategoriaProdutoRepository categoriaProdutoRepository, IProdutoRepository produtoRepository)
        {
            this.categoriaProdutoRepository = categoriaProdutoRepository;
            this.produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await categoriaProdutoRepository.GetCategorias();
            ViewData["categorias"] = categorias.ToViewModel().OrderBy(x => x.Nome).ToList();

            var produtos = (await produtoRepository.GetProdutos()).ToViewModel().OrderBy(x => x.Nome).ToList();
            ViewData["produtos"] = produtos;

            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}