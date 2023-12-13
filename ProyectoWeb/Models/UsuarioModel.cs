using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Http.Headers;
using CCIH.Entities;

namespace ProyectoWeb.Models
{
    public class UsuarioModel : IUsuarioModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;

        public UsuarioModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public UsuarioEnt? IniciarSesion(UsuarioEnt entidad)
        {
            string url = _urlApi + "api/Login/IniciarSesion";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;


                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                else
                    return null;

        }

        public int RegistrarUsuario(UsuarioEnt entidad)
        { 
            string url = _urlApi + "api/Login/RegistrarUsuario";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public List<UsuarioEnt>? ListaUsuarios()
        {
            string id  = _HttpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            long IdUsuario = long.Parse(id);
            string url = _urlApi + "api/Usuario/ListaUsuarios?idUsuario=" + IdUsuario;
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            else
                return null;
        }

		public int ActualizarEstadoUsuario(UsuarioEnt entidad)
		{
            string url = _urlApi + "api/Usuario/ActualizarEstadoUsuario";
			JsonContent obj = JsonContent.Create(entidad);
			var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public int EditarUsuario(UsuarioEnt usuario)
        {
            string url = _urlApi + "api/Usuario/EditarUsuario";
            JsonContent obj = JsonContent.Create(usuario);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public int ActualizarRolUsuario(UsuarioEnt usuario)
        {
            string url = _urlApi + "api/Usuario/ActualizarRolUsuario";
            JsonContent obj = JsonContent.Create(usuario);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return 1;
            else
                return 0;
        }

        public int ActualizarContrasena(UsuarioEnt usuario)
        {
            string IdUsuario = _HttpContextAccessor.HttpContext.Session.GetString("IdUsuario");
            usuario.IdUsuario = long.Parse(IdUsuario);
            string url = _urlApi + "api/Usuario/ActualizarContrasena";
            JsonContent obj = JsonContent.Create(usuario);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public UsuarioEnt? ConsultarUsuario(long idUsuario)
        {
            string url = _urlApi + "api/Usuario/ConsultarUsuario?idUsuario=" + idUsuario;
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            else
                return null;
        }

        public List<SelectListItem>? ConsultarRoles()
        {
            string url = _urlApi + "api/Usuario/ConsultarRoles";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }


    }
}
