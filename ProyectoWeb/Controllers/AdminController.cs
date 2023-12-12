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


    }
}
