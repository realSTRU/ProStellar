using ProStellar.Shared;
using System.Net.Http.Json;

namespace ProStellar.Client.Services.PagoServices
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _http;

        public PagoService(HttpClient http )
        {
            _http = http;
        }



        public List<Pago> ListPago { get; set; } = new List<Pago>();

        public async Task<ServiceResponse<string>> DeletePago(int Id)
        {
            var response = await _http.DeleteAsync($"api/Pago/{Id}");
            response.EnsureSuccessStatusCode();


            var result = await response.Content.ReadAsStringAsync();
            return new ServiceResponse<string> { Success = true, Data = result };
        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Pago>>>($"api/Pago");

            if(result!= null && result.Data != null)
            {
                ListPago = result.Data;
            }
        }

        public async Task<Pago> GetPagoById(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Pago>>($"api/Pago/{Id}");

            return result.Data;
        }

        public async Task<ServiceResponse<Pago>> SavePago(Pago pago)
        {
            var post = await _http.PostAsJsonAsync($"api/Pago", pago);
            var response = await post.Content.ReadFromJsonAsync<Pago>();
            var result = new ServiceResponse<Pago>
            {
                Data = response
            };

            return result;
        }
    }
}
