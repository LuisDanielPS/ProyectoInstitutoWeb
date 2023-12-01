using CCIH.Entities;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioModel _usuarioModel;

        public UsuariosController(IUsuarioModel usuarioModel)
        {
            _usuarioModel = usuarioModel;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult ListaUsuarios()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            if (entidad.PwUsuario == entidad.ConfirmarPwUsuario)
            {
                var resp = _usuarioModel.RegistrarUsuario(entidad);

                if (resp == 1)
                {
                    return RedirectToAction("RegistrarUsuario", "Usuarios");
                }
                else if (resp == 150)
                {
                    ViewBag.MsjPantalla = "Ya existe un usuario con ese correo, por favor verifique";
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

        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            var datos = _usuarioModel.ListaUsuarios();
            return View(datos);
        }

        [HttpGet]
        public IActionResult ListaUsuariosRoles()
        {
            var datos = _usuarioModel.ListaUsuarios();
            return View(datos);
        }

        [HttpGet]
        public IActionResult ActualizarEstadoUsuario(long idUsuario)
        {
            _usuarioModel.ActualizarEstadoUsuario(idUsuario);
            return RedirectToAction("ListaUsuarios", "Usuarios");
        }

        [HttpGet]
        public IActionResult ActualizarRolUsuario(long idUsuario)
        {
            var datos = _usuarioModel.ConsultarUsuario(idUsuario);
            ViewBag.Roles = _usuarioModel.ConsultarRoles();
            return View(datos);
        }

        [HttpPost]
        public IActionResult ActualizarRolUsuario(UsuarioEnt entidad)
        {
            var resp = _usuarioModel.ActualizarRolUsuario(entidad);

            if (resp == 1)
            {
                return RedirectToAction("ListaUsuariosRoles", "Usuarios");
            }
            else
            {
                ViewBag.MensajePantalla = "No se pudo actualizar su cuenta";
                ViewBag.Roles = _usuarioModel.ConsultarRoles();
                return View();
            }
        }

    }

}
