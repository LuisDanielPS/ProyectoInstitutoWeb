using CCIH.Entities;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IMatriculaModel _matriculaModel;

        public MatriculaController(IMatriculaModel matriculaModel)
        {
            _matriculaModel = matriculaModel;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarMatricula()
        {
            try
            {
                ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                ViewBag.Modalidades = _matriculaModel.ConsultarModalidades();
                ViewBag.Niveles = _matriculaModel.ConsultarNiveles();
                ViewBag.Horarios = _matriculaModel.ConsultarHorarios();
                ViewBag.Usuarios = _matriculaModel.ConsultarUsuariosPorRol();
                return View();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpPost]
        public IActionResult RegistrarMatricula(MatriculaEnt entidad)
        {
            try
            {
                if (HttpContext.Session.GetString("RolUsuario") != "1")
                {
                    var idUsu = HttpContext.Session.GetString("IdUsuario");
                    entidad.IdUsuario = int.Parse(idUsu);
                }

                var resp = _matriculaModel.RegistrarMatricula(entidad);

                if (resp == -1)
                {
                    TempData["Actualizacion1"] = true;
                    return RedirectToAction("ConsultarUsuariosMatriculados", "Matricula");
                }
                else if (resp == 150)
                {
                    ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                    ViewBag.Modalidades = _matriculaModel.ConsultarModalidades();
                    ViewBag.Niveles = _matriculaModel.ConsultarNiveles();
                    ViewBag.Horarios = _matriculaModel.ConsultarHorarios();
                    ViewBag.Usuarios = _matriculaModel.ConsultarUsuariosPorRol();
                    ViewBag.MsjPantalla = "El usuario indicado ya se encuentra registrado, por favor verifique";
                    return View();
                }
                else
                {
                    TempData["Actualizacion2"] = true;
                    return RedirectToAction("ConsultarUsuariosMatriculados", "Matricula");
                }
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }

        }

        [HttpGet]
        public IActionResult ConsultarClientes()
        {
            try
            {
                var datos = _matriculaModel.ConsultarClientes();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
           
        }

        [HttpGet]
        public IActionResult ConsultarUsuariosMatriculados()
        {
            try
            {
                bool Message1 = TempData["Actualizacion1"] as bool? ?? false;
                if (Message1)
                {
                    ViewBag.MensageExitoso = "Matricula exitosa";
                    TempData.Remove("Actualizacion1");
                }

                bool Message2 = TempData["Actualizacion2"] as bool? ?? false;
                if (Message2)
                {
                    ViewBag.MensageExitoso = "Error al procesas la matricula";
                    TempData.Remove("Actualizacion2");
                }

                var datos = _matriculaModel.ConsultarUsuariosMatriculados();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpGet]
        public IActionResult EliminarMatriculaPorUsuario(long IdUsuario)
        {
            try
            {
                var resp = _matriculaModel.EliminarMatriculaPorUsuario(IdUsuario);
                return RedirectToAction("ConsultarUsuariosMatriculados", "Matricula");
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

    }
}
