using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            try {
                return View();
            }
            catch (Exception ex) { 
                String message = ex.Message;
                return RedirectToAction("HomeError","Error");
            }
            
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



    }
}
