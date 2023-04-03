using ProStellar.Shared.Models;
using ProStellar.Shared;
namespace ProStellar.Server.Services.EmpleadoServices
{
    public interface IEmpleadoService
    {
        Task<ServiceResponse<List<Empleado>>> GetEmpleados();

        Task<ServiceResponse<Empleado>> AddEmpleado(Empleado empleado);

        Task<ServiceResponse<Empleado>> ModifyEmpleado(Empleado empleado);

        Task<ServiceResponse<Empleado>> GetEmpleado(int id);

        Task<ServiceResponse<Empleado>> DeleteEmpleado(int id);

    }
}
