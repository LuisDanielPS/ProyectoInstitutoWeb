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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistrarGrupo()
        {
            ViewBag.Cursos = _matriculaModel.ConsultarCursos();
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarGrupo(GrupoEnt entidad)
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

        public IActionResult RegistrarEstudianteGrupo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarEstudianteGrupo(long IdUsuario)
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

        public IActionResult UsuariosPorCursoMatriculado(long IdCurso, int IdGrupo)
        {
            HttpContext.Session.SetInt32("IdGrupo", IdGrupo);
            var datos = _grupoModel.UsuariosPorCursoMatriculado(IdCurso);
            return View(datos);
        }

        public IActionResult UsuariosPorGrupo(int IdGrupo)
        {
            var datos = _grupoModel.UsuariosPorGrupo(IdGrupo);
            return View(datos);
        }

        public IActionResult ConsultarGrupos()
        {
            var datos = _grupoModel.ConsultarGrupos();
            return View(datos);
        }
    }
}
