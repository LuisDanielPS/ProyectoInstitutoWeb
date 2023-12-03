using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class MatriculaEnt
    {
        public int IdMatricula { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public int IdModalidad { get; set; }
        public int IdNivel { get; set; }
        public int IdHorario { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaMatricula { get; set; }
        public DateTime DiaPago { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public int IdEstatus { get; set; }
        public string Curso { get; set; } = string.Empty;
        public string Modalidad { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public string Horario { get; set; } = string.Empty;
        public string Estatus { get; set; } = string.Empty;
    }
}