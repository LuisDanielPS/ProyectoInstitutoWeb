using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HomeError()
        {
            return View();
        }
        public IActionResult AdminError()
        {
            return View();
        }
    }
}
