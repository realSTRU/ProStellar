using ProStellar.Shared;
using ProStellar.Shared.Models;

namespace ProStellar.Client.Services.EmpleadoServices
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _http;

        public EmpleadoService( HttpClient http)
        {
            _http = http;
        }

        public List<Empleado> ListEmpleado { get; set; } = new List<Empleado>();


        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Empleado/{Id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return new ServiceResponse<string> { Success = true, Data = result };
        }

        public async Task<Empleado> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Empleado>>($"api/Empleado/{Id}");

            return result.Data;

        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Empleado>>>($"api/Empleado");

            if(result!= null && result.Data != null)
            {
                ListEmpleado = result.Data;
            }

        }


        public async Task<ServiceResponse<Empleado>> Save(Empleado empleado)
        {
            var post = await _http.PostAsJsonAsync("api/Empleado", empleado);
            var result = await post.Content.ReadFromJsonAsync<Empleado>();
            var response = new ServiceResponse<Empleado>();
            response.Data = result;

            return response;
        }
    }
}
