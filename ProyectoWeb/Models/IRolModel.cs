
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public interface IRolModel
    {
        public List<SelectListItem>? ListaRoles();

    }
}
