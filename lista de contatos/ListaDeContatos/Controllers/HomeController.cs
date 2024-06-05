using ListaDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListaDeContatos.Controllers
{
    // Controlador para gerenciar ações relacionadas à página inicial e outras páginas genéricas
    public class HomeController : Controller
    {
        // Ação que exibe a página inicial
        public IActionResult Index()
        {
            // Retorna a view da página inicial
            return View();
        }

        // Ação que exibe a página de política de privacidade
        public IActionResult Privacy()
        {
            // Retorna a view da página de privacidade
            return View();
        }

        // Ação que exibe a página de erro
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Cria um modelo de erro com o ID da solicitação atual
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            // Retorna a view da página de erro com o modelo de erro
            return View(errorViewModel);
        }
    }
}
