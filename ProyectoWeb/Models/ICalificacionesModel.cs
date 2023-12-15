using CCIH.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoWeb.Models
{
    public interface ICalificacionesModel
    {
        public int AgregarCalificaciones(CalificacionesEnt entidad);
        public List<SelectListItem>? ConsultarCursosPorUsuario(long IdUsuario);
        public List<CalificacionesEnt>? ConsultarCalificaciones();
        public CalificacionesEnt? ConsultarCalificacionPorId(long IdCalificacion);
        public int EditarCalificacion(CalificacionesEnt entidad);
        public List<CalificacionesEnt>? ConsultarCalificacionesPorUsuario(long IdUsuario);
    }
}
