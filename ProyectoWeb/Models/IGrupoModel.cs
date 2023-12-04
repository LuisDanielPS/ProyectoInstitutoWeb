using CCIH.Entities;

namespace ProyectoWeb.Models
{
    public interface IGrupoModel
    {
        public int RegistrarGrupo(GrupoEnt entidad);
        public int RegistrarEstudianteGrupo(long IdUsuario, long IdGrupo);
        public List<UsuarioEnt>? UsuariosPorCursoMatriculado(long idCurso);
        public List<GrupoEnt>? ConsultarGrupos();
        public List<UsuarioEnt>? UsuariosPorGrupo(long idGrupo);
    }
}
