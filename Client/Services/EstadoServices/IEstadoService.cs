using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Client.Services.EstadoServices
{
    public interface IEstadoService
    {
        List<Estado> ListEstado { get; set; }

        Task<Estado> Find(int Id);
        Task<ServiceResponse<Estado>> Save(Estado estado);

        Task GetList();

        Task<ServiceResponse<string>> Delete(int Id);

    }
}
