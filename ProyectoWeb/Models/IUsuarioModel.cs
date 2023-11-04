using CCIH.Entities;

namespace ProyectoWeb.Models
{
    public interface IUsuarioModel
    {
        public UsuarioEnt? IniciarSesion(UsuarioEnt entidad);
        public int RegistrarUsuario(UsuarioRegistrarEnt entidad);
    }
}
