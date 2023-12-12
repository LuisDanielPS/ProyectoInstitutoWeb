using CCIH.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoModel _grupoModel;
        private readonly IMatriculaModel _matriculaModel;

        public GrupoController(IGrupoModel grupoModel, IMatriculaModel matriculaModel)
        {
            _grupoModel = grupoModel;
            _matriculaModel = matriculaModel;
        }

        public IActionResult RegistrarGrupo()
        {
            try
            {
                ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                return View();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpPost]
        public IActionResult RegistrarGrupo(GrupoEnt entidad)
        {

            try
            {
                var resp = _grupoModel.RegistrarGrupo(entidad);

                if (resp == -1)
                {
                    ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                    return RedirectToAction("RegistrarGrupo", "Grupo");
                }
                else
                {
                    ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                    ViewBag.MsjPantalla = "No fue posible registrar el grupo";
                    return View();
                }
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        public IActionResult RegistrarEstudianteGrupo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarEstudianteGrupo(long IdUsuario)
        {
            try
            {
                var IdGrupoI = HttpContext.Session.GetInt32("IdGrupo");
                long IdGrupo = (long)IdGrupoI;
                var resp = _grupoModel.RegistrarEstudianteGrupo(IdUsuario, IdGrupo);

                if (resp == 150)
                {
                    ViewBag.MsjPantalla = "El usuario ya se encuentra asignado al grupo indicado";
                    return RedirectToAction("UsuariosPorGrupo", new { IdGrupo = IdGrupo });
                }
                else
                {
                    ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                    return RedirectToAction("UsuariosPorGrupo", new { IdGrupo = IdGrupo });
                }
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        public IActionResult UsuariosPorCursoMatriculado(long IdCurso, int IdGrupo)
        {
            try
            {
                HttpContext.Session.SetInt32("IdGrupo", IdGrupo);
                var datos = _grupoModel.UsuariosPorCursoMatriculado(IdCurso);
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        public IActionResult UsuariosPorGrupo(int IdGrupo)
        {
            try
            {
                var datos = _grupoModel.UsuariosPorGrupo(IdGrupo);
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        public IActionResult ConsultarGrupos()
        {
            try
            {
                var datos = _grupoModel.ConsultarGrupos();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }
    }
}
