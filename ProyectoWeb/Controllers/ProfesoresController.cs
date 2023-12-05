using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using CCIH.Entities;
using System.Threading.Tasks;

public class ProfesoresController : Controller
{
    private readonly IProfesorModel _profesorModel;

    public ProfesoresController(IProfesorModel profesorModel)
    {
        _profesorModel = profesorModel;
    }

    // Método para mostrar la lista de profesores
    
    public IActionResult ListarProfesores()
    {
        var datos = _profesorModel.ListarProfesores();
        return View(datos);
    }

    // Método para mostrar el formulario de nuevo profesor
    public IActionResult Create()
    {
        return View();
    }

    // Método para procesar la creación de un profesor
    public IActionResult RegistrarProfesor(ProfesorEnt entidad)
    {
        if (entidad.Correo == entidad.Correo)
        {
            var resp = _profesorModel.RegistrarProfesor(entidad);

            if (resp == 1)
            {
                return RedirectToAction("RegistrarProfesor", "Profesores");
            }
            else if (resp == 150)
            {
                ViewBag.MsjPantalla = "Ya existe un profesor con ese correo, por favor verifique";
                return View();
            }
            else
            {
                ViewBag.MsjPantalla = "No fue posible registrar su cuenta";
                return View();
            }
        }
        else
        {
            ViewBag.MsjPantalla = "Las contraseñas ingresadas no coinciden, por favor verifique";
            return View();
        }

    }

    // ... Métodos para Edit, Update, Delete ...
}

