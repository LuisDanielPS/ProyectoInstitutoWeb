namespace ProyectoWeb.Entities
{
    public class PreMatriculaEnt
    {
        public int IdPrematricula { get; set; }
        public string CorreoElectronico { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string Apellido2 { get; set; } = string.Empty;
        public int IdCurso { get; set; }
        public int IdModalidad { get; set; }
        public int IdNivel { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaPreMatricula { get; set; }

        public string Curso { get; set; } = string.Empty;
        public string Modalidad { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public string Estatus { get; set; } = string.Empty;

    }
}