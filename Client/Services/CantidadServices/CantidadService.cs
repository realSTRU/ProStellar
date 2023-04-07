using ProStellar.Shared;
using ProStellar.Shared.Models;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Runtime.InteropServices;

namespace ProStellar.Client.Services.CantidadServices
{
    public class CantidadService : ICantidadService
    {
        private readonly HttpClient _http;

        public CantidadService(HttpClient http)
        {
            _http = http;
        }

        public List<Cantidad> ListCantidad { get; set; } = new List<Cantidad>();

        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Empleado/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string> { Success = true, Data = result };
        }

        public async Task<Cantidad> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Cantidad>>($"api/Cantidad/{Id}");

            return result.Data;
        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Cantidad>>>($"api/Cantidad");

            if(result != null && result.Data != null)
            {
                ListCantidad = result.Data;
            }
        }

        public async Task<ServiceResponse<Cantidad>> Save(Cantidad cantidad)
        {
            var post = await _http.PostAsJsonAsync("api/Cantidad", cantidad);
            var result = await post.Content.ReadFromJsonAsync<Cantidad>();
            var response = new ServiceResponse<Cantidad>();
            response.Data = result;

            return response;
        }
    }
}

