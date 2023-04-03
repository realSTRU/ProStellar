using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Services.CantidadService
{
    public interface ICantidadService
    {
        Task<ServiceResponse<Cantidad>> GetCantidadAsync(int Id);
        Task<ServiceResponse<List<Cantidad>>> GetAllCantidadsAsync();
        Task<ServiceResponse<Cantidad>> Guardar(Cantidad Cantidad);
        Task<ServiceResponse<Cantidad>> Modificar(Cantidad Cantidad);
        Task<ServiceResponse<Cantidad>> Eliminar(int CantidadId);
    }
}

