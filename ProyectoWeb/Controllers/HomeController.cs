using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using System.Diagnostics;

namespace ProyectoWeb.Controllers
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Acerca()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Cursos()
        {
            return View();
        }

        public IActionResult Ing_Intensivo_P()
        {
            return View();
        }

        public IActionResult Ing_Intensivo_V()
        {
            return View();
        }

        public IActionResult Ing_Niños_V()
        {
            return View();
        }

        public IActionResult Ing_Semi_Intensivo_P()
        {
            return View();
        }

        public IActionResult Ing_Semi_Intensivo_V()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginReset()
        {
            return View();
        }

        public IActionResult Portu_Semi_Intensivo_V()
        {
            return View();
        }

        public IActionResult PreMatricular()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

    }
}