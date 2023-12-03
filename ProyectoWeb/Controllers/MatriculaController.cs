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
            ViewBag.Cursos = _matriculaModel.ConsultarCursos();
            ViewBag.Modalidades = _matriculaModel.ConsultarModalidades();
            ViewBag.Niveles = _matriculaModel.ConsultarNiveles();
            ViewBag.Horarios = _matriculaModel.ConsultarHorarios();
            ViewBag.Usuarios = _matriculaModel.ConsultarUsuariosPorRol();
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarMatricula(MatriculaEnt entidad)
        {
            var resp = _matriculaModel.RegistrarMatricula(entidad);

            if (resp == -1)
            {
                ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                ViewBag.Modalidades = _matriculaModel.ConsultarModalidades();
                ViewBag.Niveles = _matriculaModel.ConsultarNiveles();
                ViewBag.Horarios = _matriculaModel.ConsultarHorarios();
                ViewBag.Usuarios = _matriculaModel.ConsultarUsuariosPorRol();
                return RedirectToAction("RegistrarMatricula", "Matricula");
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
                ViewBag.Cursos = _matriculaModel.ConsultarCursos();
                ViewBag.Modalidades = _matriculaModel.ConsultarModalidades();
                ViewBag.Niveles = _matriculaModel.ConsultarNiveles();
                ViewBag.Horarios = _matriculaModel.ConsultarHorarios();
                ViewBag.Usuarios = _matriculaModel.ConsultarUsuariosPorRol();
                ViewBag.MsjPantalla = "No fue posible registrar la matrícula";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ConsultarClientes()
        {
            var datos = _matriculaModel.ConsultarClientes();
            return View(datos);
        }

        [HttpGet]
        public IActionResult ConsultarUsuariosMatriculados()
        {
            var datos = _matriculaModel.ConsultarUsuariosMatriculados();
            return View(datos);
        }

    }
}
