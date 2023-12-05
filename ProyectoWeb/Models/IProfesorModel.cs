using CCIH.Entities;
using System.Collections.Generic;

namespace ProyectoWeb.Models
{
    public interface IProfesorModel
    {
        public int RegistrarProfesor(ProfesorEnt profesor);
        public List<ProfesorEnt>? ListarProfesores();
        public ProfesorEnt ConsultarProfesor(long idProfesor);
        public int ActualizarProfesor(ProfesorEnt profesor);
        public int CambiarEstadoProfesor(long idProfesor, bool nuevoEstado);
    }
}

