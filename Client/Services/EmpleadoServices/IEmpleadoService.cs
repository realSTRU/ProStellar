using ProStellar.Shared;
using ProStellar.Shared.Models;
namespace ProStellar.Client.Services.EmpleadoServices
{
    public interface IEmpleadoService
    {
        List<Empleado> ListEmpleado { get; set; }

        Task<Empleado> Find(int Id);
        Task<ServiceResponse<Empleado>> Save(Empleado empleado);

        Task GetList();

        Task<ServiceResponse<string>> Delete(int Id);
    }
}
