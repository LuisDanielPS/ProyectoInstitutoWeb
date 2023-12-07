using CCIH.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public interface IProfesorModel
    {
        public Task<int> RegistrarProfesorAsync(ProfesorEnt profesor);
        public Task<List<ProfesorEnt>> ListarProfesoresAsync();
        public Task<ProfesorEnt> ConsultarProfesorAsync(long idProfesor);
        public Task<int> ActualizarProfesorAsync(ProfesorEnt profesor);
        public Task<int> CambiarEstadoProfesorAsync(long idProfesor, bool nuevoEstado);
    }
}


