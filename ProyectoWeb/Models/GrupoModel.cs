using CCIH.Entities;

namespace ProyectoWeb.Models
{
    public class GrupoModel : IGrupoModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;

        public GrupoModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public int RegistrarGrupo(GrupoEnt entidad)
        {
            string url = _urlApi + "api/Grupo/RegistrarGrupo";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public int RegistrarEstudianteGrupo(GrupoEstudiantesEnt entidad)
        {
            string url = _urlApi + "api/Grupo/RegistrarEstudianteGrupo";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public List<UsuarioEnt>? UsuariosPorCursoMatriculado(long idCurso)
        {
            string url = _urlApi + "api/Grupo/UsuariosPorCursoMatriculado?idCurso=" + idCurso;
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            else
                return null;
        }

        public List<GrupoEnt>? ConsultarGrupos()
        {
            string url = _urlApi + "api/Grupo/ConsultarGrupos";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<GrupoEnt>>().Result;
            else
                return null;
        }

    }
}
