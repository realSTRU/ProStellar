using System.Linq.Expressions;
using ProStellar.Shared;

namespace ProStellar.Client.Services.NominaServices
{
    public class NominaService : INominaService
    {
        private readonly HttpClient _http;

        public NominaService(HttpClient http)
        {
            _http = http;
        }

        public List<Nomina> ListNomina { get; set; } = new List<Nomina>();

        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Nomina/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return new ServiceResponse<string>
            {
                Success = true,
                Data = result
            };
        }

        public async Task<Nomina> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Nomina>>($"api/Nomina/{Id}");
            return result.Data;
        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Nomina>>>("api/Nomina");

            if (result != null && result.Data != null)
            {
                ListNomina = result.Data;
            }
        }

        public async Task<ServiceResponse<Nomina>> Save(Nomina nomina)
        {
            var post = await _http.PostAsJsonAsync("api/Nomina", nomina);
            var response = await post.Content.ReadFromJsonAsync<Nomina>();
            var result = new ServiceResponse<Nomina>();

            result.Data = response;

            return result;
        }
    }
}
