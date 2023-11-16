using CCIH.Entities;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using System.Diagnostics;

namespace ProyectoWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioModel _usuarioModel;

        public LoginController(IUsuarioModel usuarioModel)
        {
            _usuarioModel = usuarioModel;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            bool registroExitoso = TempData["RegistroExitoso"] as bool? ?? false;

            if (registroExitoso)
            {
                ViewBag.RegistroExitoso = "Registro Exitoso";
                TempData.Remove("RegistroExitoso");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(UsuarioEnt entidad)
        {
           
            if (entidad.Usuario != null && entidad.PwUsuario != null)
            {
                var resp = _usuarioModel.IniciarSesion(entidad);
                if (resp != null)
                {
                    HttpContext.Session.SetString("NombreUsuario", resp.Nombre);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.MsjPantalla = "Usuario y/o clave incorrectos, por favor verifique";
                    return View();
                }
            } else
            {
                ViewBag.MsjPantalla = "Por favor, digite su usuario y contraseña";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Registrarse(UsuarioEnt entidad)
        {
                if (entidad.PwUsuario == entidad.ConfirmarPwUsuario)
                {
                    var resp = _usuarioModel.RegistrarUsuario(entidad);

                    if (resp == 1)
                    {
                        TempData["RegistroExitoso"] = true;
                        return RedirectToAction("IniciarSesion", "Login");
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
    }
}
