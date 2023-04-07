using ProStellar.Shared.Models;
using ProStellar.Shared;
namespace ProStellar.Client.Services.EmpleadoServices
{
    public class EmpleadoService : IEmpleadoService
    {
        public List<Empleado> ListEmpleado { get; set; }

        public Task<ServiceResponse<string>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Empleado> Find(int Id)
        {
            throw new NotImplementedException();
        }

        public Task GetList()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Empleado>> Save(Empleado empleado)
        {
            throw new NotImplementedException();
        }
    }
}
