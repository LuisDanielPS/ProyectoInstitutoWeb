using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCIH.Entities
{
    public class UsuarioRegistrarEnt
    {
        public string CorreoElectronico { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Contrasenna { get; set; }
        public string ConfirmarContrasenna { get; set; }


    }
}