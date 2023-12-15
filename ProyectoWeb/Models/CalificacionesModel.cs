using CCIH.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoWeb.Models
{
    public class CalificacionesModel : ICalificacionesModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;

        public CalificacionesModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public int AgregarCalificaciones(CalificacionesEnt entidad)
        {
            string url = _urlApi + "api/Calificaciones/AgregarCalificaciones";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public List<SelectListItem>? ConsultarCursosPorUsuario(long IdUsuario)
        {
            string url = _urlApi + "api/Calificaciones/ConsultarCursosPorUsuario?IdUsuario=" + IdUsuario;
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

        public List<CalificacionesEnt>? ConsultarCalificaciones()
        {
            string url = _urlApi + "api/Calificaciones/ConsultarCalificaciones";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<CalificacionesEnt>>().Result;
            else
                return null;
        }

        public CalificacionesEnt? ConsultarCalificacionPorId(long IdCalificacion)
        {
            string url = _urlApi + "api/Calificaciones/ConsultarCalificacionPorId?IdCalificacion=" + IdCalificacion;
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CalificacionesEnt>().Result;
            else
                return null;
        }

        public int EditarCalificacion(CalificacionesEnt entidad)
        {
            string url = _urlApi + "api/Calificaciones/EditarCalificacion";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public List<CalificacionesEnt>? ConsultarCalificacionesPorUsuario(long IdUsuario)
        {
            string url = _urlApi + "api/Calificaciones/ConsultarCalificacionesPorUsuario?IdUsuario=" + IdUsuario;
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<CalificacionesEnt>>().Result;
            else
                return null;
        }
    }
}
