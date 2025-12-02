using System.Diagnostics;
using ListaTareasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaTareasApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Siempre mostrar la página de inicio
            // Si el usuario está autenticado verá "Ver mis tareas"
            // Si no está autenticado verá "Iniciar Sesión" y "Registrarse"
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}