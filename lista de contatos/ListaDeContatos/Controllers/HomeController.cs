using ListaDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListaDeContatos.Controllers
{
    // Controlador para gerenciar a��es relacionadas � p�gina inicial e outras p�ginas gen�ricas
    public class HomeController : Controller
    {
        // A��o que exibe a p�gina inicial
        public IActionResult Index()
        {
            // Retorna a view da p�gina inicial
            return View();
        }

        // A��o que exibe a p�gina de pol�tica de privacidade
        public IActionResult Privacy()
        {
            // Retorna a view da p�gina de privacidade
            return View();
        }

        // A��o que exibe a p�gina de erro
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Cria um modelo de erro com o ID da solicita��o atual
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            // Retorna a view da p�gina de erro com o modelo de erro
            return View(errorViewModel);
        }
    }
}
