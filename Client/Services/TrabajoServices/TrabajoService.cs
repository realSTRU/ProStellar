using System.Net.Http.Json;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Client.Services.TrabajoServices
{
    public class TrabajoService : ITrabajoService
    {

        private readonly HttpClient _http;

        public TrabajoService(HttpClient http)
        {
            _http = http;
        }
        public List<Trabajo> ListTrabajo { get; set; } = new List<Trabajo>();

        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Trabajo/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string>
            {
                Success = true,
                Data
            = result
            };
        }

        public async Task<Trabajo> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Trabajo>>($"api/Trabajo/{Id}");

            return result.Data;
        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Trabajo>>>($"api/Trabajo");

            if (result != null && result.Data != null)
            {
                ListTrabajo = result.Data;
            }
        }

        public async Task<ServiceResponse<Trabajo>> Save(Trabajo trabajo)
        {
            var post = await _http.PostAsJsonAsync($"api/Trabajo", trabajo);
            var result = await post.Content.ReadFromJsonAsync<Trabajo>();
            var response = new ServiceResponse<Trabajo>();
            response.Data = result;
            return response;
        }
    }
}
