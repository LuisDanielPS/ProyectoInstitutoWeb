using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoWeb.Entities;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace ProyectoWeb.Models
{
    public class RolModel : IRolModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;

        public RolModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public List<SelectListItem>? ListaRoles()
        {
            string url = _urlApi + "api/Rol/ListaRoles";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            else
                return null;
        }

    }
}
