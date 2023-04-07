using Azure;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using ProStellar.Shared;
using ProStellar.Shared.Models;

namespace ProStellar.Server.Services.PagoService
{
    public interface IPagoService
    {
        Task<ServiceResponse<Pago>> GetPagoAsync(int Id);
        Task<ServiceResponse<List<Pago>>> GetAllPagosAsync();
        Task<ServiceResponse<Pago>> Guardar(Pago Pago);
        Task<ServiceResponse<Pago>> Modificar(Pago Pago);
        Task<ServiceResponse<Pago>> Eliminar(int PagoId);
    }

}
