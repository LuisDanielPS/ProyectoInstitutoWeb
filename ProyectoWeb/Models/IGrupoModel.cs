using CCIH.Entities;

namespace ProyectoWeb.Models
{
    public interface IGrupoModel
    {
        public int RegistrarGrupo(GrupoEnt entidad);
        public int RegistrarEstudianteGrupo(GrupoEstudiantesEnt entidad);
        public List<UsuarioEnt>? UsuariosPorCursoMatriculado(long idCurso);
        public List<GrupoEnt>? ConsultarGrupos();
    }
}
