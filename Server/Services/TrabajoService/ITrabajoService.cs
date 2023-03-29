using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Services.TrabajoService
{
    public interface ITrabajoService
    {
        Task<ServiceResponse<Trabajo>> GetTrabajoAsync(int Id);
        Task<ServiceResponse<List<Trabajo>>> GetAllTrabajosAsync();
        Task<ServiceResponse<Trabajo>> Guardar(Trabajo Trabajo);
        Task<ServiceResponse<Trabajo>> Modificar(Trabajo Trabajo);
        Task<ServiceResponse<Trabajo>> Eliminar(int TrabajoId);
    }
}
