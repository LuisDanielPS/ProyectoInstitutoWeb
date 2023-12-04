using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class GrupoEnt
    {
        public int IdGrupo { get; set; }
        public int IdEstatus { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; } = string.Empty;
    }
}