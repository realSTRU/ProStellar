using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Services.EstadoService
{
        public interface IEstadoService
        {
            Task<ServiceResponse<Estado>> GetEstadoAsync(int Id);
            Task<ServiceResponse<List<Estado>>> GetAllEstadosAsync();
            Task<ServiceResponse<Estado>> Guardar(Estado Estado);
            Task<ServiceResponse<Estado>> Modificar(Estado Estado);
            Task<ServiceResponse<Estado>> Eliminar(int EstadoId);
        }
}

