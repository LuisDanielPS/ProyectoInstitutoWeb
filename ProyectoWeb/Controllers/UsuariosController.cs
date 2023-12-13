using CCIH.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioModel _usuarioModel;
        private readonly IRolModel _rolModel;

        public UsuariosController(IUsuarioModel usuarioModel, IRolModel rolModel)
        {
            _usuarioModel = usuarioModel;
            _rolModel = rolModel;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            try
            {
                ViewBag.RolesCombo = _rolModel.ListaRoles();

                return View();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }               

        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {
                if (entidad.PwUsuario == entidad.ConfirmarPwUsuario)
                {
                    var resp = _usuarioModel.RegistrarUsuario(entidad);

                    if (resp == 1)
                    {
                        TempData["Actualizacion1"] = true;
                        return RedirectToAction("ListaUsuarios", "Usuarios");
                    }
                    else if (resp == 150)
                    {
                        ViewBag.MsjPantalla = "Ya existe un usuario con ese correo, por favor verifique";
                        ViewBag.RolesCombo = _rolModel.ListaRoles();
                        return View();
                    }
                    TempData["Actualizacion2"] = true;
                    return RedirectToAction("ListaUsuarios", "Usuarios");
                }
                else
                {
                    ViewBag.RolesCombo = _rolModel.ListaRoles();
                    ViewBag.MsjPantalla = "Las contraseñas ingresadas no coinciden, por favor verifique";
                    return View();
                }
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            

        }

        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            bool Message1 = TempData["Actualizacion1"] as bool? ?? false;
            if (Message1)
            {
                ViewBag.MensageExitoso = "Usuario Creado";
                TempData.Remove("Actualizacion1");
            }

            bool Message2 = TempData["Actualizacion2"] as bool? ?? false;
            if (Message2)
            {
                ViewBag.MensageError = "Hubo un problema al crear el usuario";
                TempData.Remove("Actualizacion2");
            }

            try
            {
                var datos = _usuarioModel.ListaUsuarios();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpGet]
        public IActionResult ListaUsuariosRoles()
        {
            try
            {
                var datos = _usuarioModel.ListaUsuarios();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpGet]
        public IActionResult ActualizarEstadoUsuario(long q)
        {
            var entidad = new UsuarioEnt();
            entidad.IdUsuario= q;
            try
            {
                _usuarioModel.ActualizarEstadoUsuario(entidad);
                return RedirectToAction("ListaUsuarios", "Usuarios");
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpGet]
        public IActionResult ActualizarRolUsuario(long idUsuario)
        {
            try
            {
                var datos = _usuarioModel.ConsultarUsuario(idUsuario);
                ViewBag.Roles = _usuarioModel.ConsultarRoles();
                return View(datos);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpPost]
        public IActionResult ActualizarRolUsuario(UsuarioEnt entidad)
        {
            try
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
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpGet]
        public IActionResult PerfilUsuario(long i)
        {
            try
            {
                ViewBag.RolesCombo = _rolModel.ListaRoles();
                var resp = _usuarioModel.ConsultarUsuario(i);


                bool Message1 = TempData["Actualizacion1"] as bool? ?? false;
                if (Message1)
                {
                    ViewBag.MensageExitoso = "Informacion Actualizada";
                    TempData.Remove("Actualizacion1");
                }

                bool Message2 = TempData["Actualizacion2"] as bool? ?? false;
                if (Message2)
                {
                    ViewBag.MensageExitoso = "Error al actualizar la informacion";
                    TempData.Remove("Actualizacion2");
                }


                return View(resp);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }


        [HttpPost]
        public IActionResult PerfilUsuario(UsuarioEnt entidad)
        {
            try
            {
                var resp = _usuarioModel.EditarUsuario(entidad);
                long i = entidad.IdUsuario;
                if (resp > 0)
                {
                    TempData["Actualizacion1"] = true;

                    return RedirectToAction("PerfilUsuario", new { i });
                }
                TempData["Actualizacion2"] = true;
                return RedirectToAction("PerfilUsuario", new { i });
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                return RedirectToAction("HomeError", "Error");
            }
            
        }

        [HttpGet]
        public IActionResult ActualizarContrasena()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ActualizarContrasena(UsuarioEnt entidad)
        {

            if (entidad.PwUsuarioAnterior.Trim() == entidad.PwUsuario.Trim())
            {
                ViewBag.MensajePantalla = "Debe ingresar una contraseña nueva";
                return View();
            }

            var resp = _usuarioModel.ActualizarContrasena(entidad);

            if (resp == 1)
                return RedirectToAction("Index", "Admin");
            else
            {
                ViewBag.MensajePantalla = "No se pudo actualizar su contraseña";
                return View();
            }
        }

    }

}
