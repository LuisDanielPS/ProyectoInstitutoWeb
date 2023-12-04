using CCIH.Entities;
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

        [HttpPost]
        public IActionResult RegistrarEstudianteGrupo(GrupoEstudiantesEnt entidad)
        {
            _grupoModel.RegistrarEstudianteGrupo(entidad);
            ViewBag.Cursos = _matriculaModel.ConsultarCursos();
            return RedirectToAction("RegistrarGrupo", "Grupo");
        }

        public IActionResult UsuariosPorCursoMatriculado(long IdCurso)
        {
            var datos = _grupoModel.UsuariosPorCursoMatriculado(IdCurso);
            return View(datos);
        }

        public IActionResult ConsultarGrupos()
        {
            var datos = _grupoModel.ConsultarGrupos();
            return View(datos);
        }
    }
}
