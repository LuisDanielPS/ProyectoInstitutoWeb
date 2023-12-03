using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class UsuariosMatriculadosEnt
    {
        public string Usuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string Apellido2 { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime FechaMatricula { get; set; }
        public DateTime DiaPago { get; set; }
        public string Curso { get; set; } = string.Empty;
        public string Modalidad { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public string Horario { get; set; } = string.Empty;
    }
}