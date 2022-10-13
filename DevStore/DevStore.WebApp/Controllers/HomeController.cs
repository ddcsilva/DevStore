using DevStore.Repository.Interface;
using DevStore.ViewModel;
using DevStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevStore.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoriaProdutoRepository categoriaProdutoRepository;

        public HomeController(ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            this.categoriaProdutoRepository = categoriaProdutoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await categoriaProdutoRepository.GetCategorias();
            ViewData["categorias"] = categorias.ToViewModel().OrderBy(x => x.Nome).ToList();

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