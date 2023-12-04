using CCIH.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoWeb.Models
{
    public class MatriculaModel : IMatriculaModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;

        public MatriculaModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public int RegistrarMatricula(MatriculaEnt entidad)
        {
            string url = _urlApi + "api/Matricula/RegistrarMatricula";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public List<SelectListItem>? ConsultarCursos()
        {
            string url = _urlApi + "api/Matricula/ConsultarCursos";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

        public List<SelectListItem>? ConsultarModalidades()
        {
            string url = _urlApi + "api/Matricula/ConsultarModalidades";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

        public List<SelectListItem>? ConsultarNiveles()
        {
            string url = _urlApi + "api/Matricula/ConsultarNiveles";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

        public List<SelectListItem>? ConsultarHorarios()
        {
            string url = _urlApi + "api/Matricula/ConsultarHorarios";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

        public List<SelectListItem>? ConsultarUsuariosPorRol()
        {
            string url = _urlApi + "api/Matricula/ConsultarUsuariosPorRol";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

        public List<UsuarioEnt>? ConsultarClientes()
        {
            string url = _urlApi + "api/Matricula/ConsultarClientes";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            else
                return null;
        }

        public List<UsuariosMatriculadosEnt>? ConsultarUsuariosMatriculados()
        {
            string url = _urlApi + "api/Matricula/ConsultarUsuariosMatriculados";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<UsuariosMatriculadosEnt>>().Result;
            else
                return null;
        }

        public int EliminarMatriculaPorUsuario(long IdUsuario)
        {
            UsuariosMatriculadosEnt usuario = new UsuariosMatriculadosEnt();
            usuario.IdUsuario = IdUsuario;
            string url = _urlApi + "api/Matricula/EliminarMatriculaPorUsuario";
            JsonContent obj = JsonContent.Create(usuario);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

    }
}
