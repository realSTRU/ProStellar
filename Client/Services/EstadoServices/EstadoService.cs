using ProStellar.Shared;
using ProStellar.Shared.Models;

namespace ProStellar.Client.Services.EstadoServices
{
    public class EstadoService : IEstadoService
    {
        private readonly HttpClient _http;

        public EstadoService(HttpClient http)
        {
            _http = http;
        }

        public List<Estado> ListEstado { get; set; } = new List<Estado>();

        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Estado/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return new ServiceResponse<string>
            {
                Success = true,
                Data = result
            };
            
        }

        public async Task<Estado> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Estado>>($"api/Estado/{Id}");

            return result.Data;
        }

        public async Task GetList()
        {

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Estado>>>($"api/Estado");

            if(result != null && result.Data != null)
            {
                ListEstado = result.Data;
            }
        }

        public async Task<ServiceResponse<Estado>> Save(Estado estado)
        {
            var post = await _http.PostAsJsonAsync("api/Estado", estado);
            var response = await post.Content.ReadFromJsonAsync<Estado>();
            var result = new ServiceResponse<Estado>
            {
                Data = response
            };

            return result;
        }
    }
}
