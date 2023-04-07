using ProStellar.Shared.Models;
using ProStellar.Shared;
namespace ProStellar.Client.Services.TrabajoServices
{
    public interface ITrabajoService
    {
        List<Trabajo> ListTrabajo { get; set; }
        Task<Trabajo> Find(int Id);
        Task<ServiceResponse<Trabajo>> Save(Trabajo trabajo);
        Task GetList();
        Task<ServiceResponse<string>> Delete(int Id);
    }
}
