using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Client.Services.CantidadServices
{
    public interface ICantidadService
    {

        List<Cantidad> ListCantidad { get; set; }

        Task<Cantidad> Find(int Id);
        Task<ServiceResponse<Cantidad>> Save(Cantidad cantidad);

        Task GetList();

        Task<ServiceResponse<string>> Delete(int Id);

    }
}
