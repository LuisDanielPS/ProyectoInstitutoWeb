namespace CCIH.Entities
{
    public class CalificacionesEnt
    {
        public int IdCalificacion { get; set; }
        public long IdUsuario { get; set; }
        public string nombreUsuario { get; set; } = string.Empty;
        public long IdCurso { get; set; }
        public string nombreCurso { get; set; } = string.Empty;
        public decimal PrimerParcial { get; set; }
        public decimal SegundoParcial { get; set; }
        public decimal TercerParcial { get; set; }
        public decimal NotaFinal { get; set; }
    }
}
