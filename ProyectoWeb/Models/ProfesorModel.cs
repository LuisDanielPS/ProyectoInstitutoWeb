using CCIH.Entities;
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
        private readonly string _urlApi;

        public ProfesorModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _urlApi = configuration.GetValue<string>("Llaves:urlApi");
        }

        public async Task<int> RegistrarProfesorAsync(ProfesorEnt profesor)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_urlApi}/RegistrarProfesor", profesor);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<ProfesorEnt>> ListarProfesoresAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProfesorEnt>>($"{_urlApi}/ListarProfesores");
            return response ?? new List<ProfesorEnt>();
        }

        public async Task<ProfesorEnt> ConsultarProfesorAsync(long idProfesor)
        {
            var response = await _httpClient.GetFromJsonAsync<ProfesorEnt>($"{_urlApi}/ConsultarProfesor/{idProfesor}");
            return response;
        }

        public async Task<int> ActualizarProfesorAsync(ProfesorEnt profesor)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_urlApi}/ActualizarProfesor/{profesor.IdProfesor}", profesor);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> CambiarEstadoProfesorAsync(long idProfesor, bool nuevoEstado)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_urlApi}/CambiarEstadoProfesor/{idProfesor}", nuevoEstado);
            return response.IsSuccessStatusCode ? 1 : 0;
        }
    }
}


