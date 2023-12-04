using CCIH.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoWeb.Models
{
    public interface IMatriculaModel
    {
        public int RegistrarMatricula(MatriculaEnt entidad);
        public List<SelectListItem>? ConsultarCursos();
        public List<SelectListItem>? ConsultarModalidades();
        public List<SelectListItem>? ConsultarNiveles();
        public List<SelectListItem>? ConsultarHorarios();
        public List<SelectListItem>? ConsultarUsuariosPorRol();
        public List<UsuarioEnt>? ConsultarClientes();
        public List<UsuariosMatriculadosEnt>? ConsultarUsuariosMatriculados();
        public int EliminarMatriculaPorUsuario(long IdUsuario);
    }
}
