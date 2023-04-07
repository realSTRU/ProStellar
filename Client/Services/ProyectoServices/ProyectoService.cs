using Microsoft.JSInterop;

namespace ProStellar.Client.Services.ProyectoServices
{
    public class ProyectoService : IProyectoService
    {
        private readonly HttpClient _http;

        public ProyectoService(HttpClient http)
        {
            _http = http;
        }


        public List<Proyecto> ListProyecto { get; set; } = new List<Proyecto>();

        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Proyecto/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return new ServiceResponse<string> { Success = true, Data = result };
        }

        public async Task<Proyecto> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Proyecto>>($"api/Proyecto/{Id}");

            return result.Data;
        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Proyecto>>>($"api/Proyecto");

            if(result != null && result.Data != null)
            {
                ListProyecto = result.Data;
            }
        }

        public async Task<ServiceResponse<Proyecto>> Save(Proyecto proyecto)
        {
            var post = await _http.PostAsJsonAsync($"api/Proyecto", proyecto);
            var response = await post.Content.ReadFromJsonAsync<Proyecto>();
            var result = new ServiceResponse<Proyecto>();
            result.Data = response;

            return result;

        }
    }
}
