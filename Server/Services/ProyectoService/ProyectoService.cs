using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Services.ProyectoService
{
    public interface IProyectoService
    {
        Task<ServiceResponse<Proyecto>> GetProyectoAsync(int Id);
        Task<ServiceResponse<List<Proyecto>>> GetAllProyectosAsync();
        Task<ServiceResponse<Proyecto>> Guardar(Proyecto Proyecto);
        Task<ServiceResponse<Proyecto>> Modificar(Proyecto Proyecto);
        Task<ServiceResponse<Proyecto>> Eliminar(int ProyectoId);
    }
}

