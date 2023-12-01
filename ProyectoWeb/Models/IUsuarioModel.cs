using CCIH.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoWeb.Models
{
    public interface IUsuarioModel
    {
        public UsuarioEnt? IniciarSesion(UsuarioEnt entidad);
        public int RegistrarUsuario(UsuarioEnt entidad);
        public List<UsuarioEnt>? ListaUsuarios();
        public int ActualizarEstadoUsuario(long idUsuario);
        public int ActualizarRolUsuario(UsuarioEnt usuario);
        public List<SelectListItem>? ConsultarRoles();
        public UsuarioEnt? ConsultarUsuario(long idUsuario);

    }
}
