using CCIH.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ICalificacionesModel _calificacionesModel;

        public CalificacionesController(ICalificacionesModel calificacionesModel)
        {
            _calificacionesModel = calificacionesModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AgregarCalificaciones(string IdUsuario)
        {
            HttpContext.Session.SetString("IdUsuarioCalificar", IdUsuario);
            ViewBag.Cursos = _calificacionesModel.ConsultarCursosPorUsuario(int.Parse(IdUsuario));
            return View();
        }

        [HttpPost]
        public IActionResult AgregarCalificaciones(CalificacionesEnt entidad)
        {
            try
            {
                var usuario = HttpContext.Session.GetString("IdUsuarioCalificar");

                entidad.IdUsuario = int.Parse(usuario);

                var resp = _calificacionesModel.AgregarCalificaciones(entidad);

                if (entidad.IdCurso == 0 || entidad.PrimerParcial == 0 || entidad.SegundoParcial == 0 || entidad.TercerParcial == 0)
                {
                    ViewBag.Cursos = _calificacionesModel.ConsultarCursosPorUsuario(entidad.IdUsuario);
                    ViewBag.MsjPantalla = "Debe completar todos los campos";
                    return View();
                }

                if (resp == 150)
                {
                    ViewBag.Cursos = _calificacionesModel.ConsultarCursosPorUsuario(entidad.IdUsuario);
                    ViewBag.MsjPantalla = "La nota de este estudiante ya fue registrada";
                    return View();
                }
                else
                {
                    return RedirectToAction("AgregarCalificaciones", new {entidad.IdUsuario});
                }
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }

        }

        [HttpGet]
        public IActionResult ConsultarCalificaciones()
        {
            try
            {
                var datos = _calificacionesModel.ConsultarCalificaciones();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }

        }

        [HttpGet]
        public IActionResult EditarCalificacion(long IdCalificacion)
        {
            var datos = _calificacionesModel.ConsultarCalificacionPorId(IdCalificacion);
            return View(datos);
        }

        [HttpPost]
        public IActionResult EditarCalificacion(CalificacionesEnt entidad)
        {
            try
            {

                var resp = _calificacionesModel.EditarCalificacion(entidad);

                if (entidad.PrimerParcial == 0 || entidad.SegundoParcial == 0 || entidad.TercerParcial == 0)
                {
                    ViewBag.Cursos = _calificacionesModel.ConsultarCalificacionPorId(entidad.IdCalificacion);
                    ViewBag.MsjPantalla = "Debe completar todos los campos";
                    return View();
                }
                else
                {
                    return RedirectToAction("EditarCalificacion", new { entidad.IdCalificacion });
                }
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }

        }

        [HttpGet]
        public IActionResult ConsultarCalificacionesPorUsuario()
        {
            try
            {
                var IdUsu = HttpContext.Session.GetString("IdUsuario");
                var IdUsuario = int.Parse(IdUsu);
                var datos = _calificacionesModel.ConsultarCalificacionesPorUsuario(IdUsuario);
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
