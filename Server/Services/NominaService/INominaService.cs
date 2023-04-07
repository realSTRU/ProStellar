using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Services.NominaService
{
    public interface INominaService
    {
        Task<ServiceResponse<Nomina>> GetNominaAsync(int Id);
        Task<ServiceResponse<List<Nomina>>> GetAllNominasAsync();
        Task<ServiceResponse<Nomina>> Guardar(Nomina Nomina);
        Task<ServiceResponse<Nomina>> Modificar(Nomina Nomina);
        Task<ServiceResponse<Nomina>> Eliminar(int NominaId);
    }
}
