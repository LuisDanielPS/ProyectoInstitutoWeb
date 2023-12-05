using CCIH.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProyectoWeb.Models
{
    public class ProfesorModel : IProfesorModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _urlApi;

        public ProfesorModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _urlApi = _configuration.GetValue<string>("Llaves:urlApi");
        }

        public int RegistrarProfesor(ProfesorEnt profesor)
        {
            var response = _httpClient.PostAsJsonAsync($"{_urlApi}/api/Profesor", profesor).Result;
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public List<ProfesorEnt> ListarProfesores()
        {
            var response = _httpClient.GetFromJsonAsync<List<ProfesorEnt>>($"{_urlApi}/api/Profesor").Result;
            return response ?? new List<ProfesorEnt>();
        }

        public ProfesorEnt ConsultarProfesor(long idProfesor)
        {
            var response = _httpClient.GetFromJsonAsync<ProfesorEnt>($"{_urlApi}/api/Profesor/{idProfesor}").Result;
            return response;
        }

        public int ActualizarProfesor(ProfesorEnt profesor)
        {
            var response = _httpClient.PutAsJsonAsync($"{_urlApi}/api/Profesor/{profesor.IdProfesor}", profesor).Result;
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public int CambiarEstadoProfesor(long idProfesor, bool nuevoEstado)
        {
            // Aquí necesitarás un poco más de lógica para enviar el estado correcto en la solicitud,
            // dependiendo de cómo esté implementado tu endpoint de la API para cambiar el estado.
            var response = _httpClient.PutAsJsonAsync($"{_urlApi}/api/Profesor/CambiarEstado/{idProfesor}", nuevoEstado).Result;
            return response.IsSuccessStatusCode ? 1 : 0;
        }
    }
}

