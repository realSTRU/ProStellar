using System.Net.Http.Json;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Client.Services.TipoPagoServices
{
    public class TipoPagoService : ITipoPagoService
    {

        private readonly HttpClient _http;

        public TipoPagoService(HttpClient http)
        {
            _http = http;
        }

        public List<TipoPago> ListTipoPago { get; set; } = new List<TipoPago>();

        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/TipoPago/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return new ServiceResponse<string> { Success = true, Data = result };

        }

        public async Task<TipoPago> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TipoPago>>($"api/TipoPago/{Id}");
            return result.Data;

        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TipoPago>>>($"api/TipoPago");

            if (result != null && result.Data != null)
            {
                ListTipoPago = result.Data;
            }
        }

        public async Task<ServiceResponse<TipoPago>> Save(TipoPago tipoPago)
        {
            var post = await _http.PostAsJsonAsync("api/TipoPago", tipoPago);
            var result = await post.Content.ReadFromJsonAsync<TipoPago>();
            var response = new ServiceResponse<TipoPago>();
            response.Data = result;

            return response;
        }
    }
}
