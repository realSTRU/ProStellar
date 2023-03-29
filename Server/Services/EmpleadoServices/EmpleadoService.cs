using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;

namespace ProStellar.Server.Services.EmpleadoServices
{
    public class EmpleadoService : IEmpleadoService
    {

        private readonly Contexto _contexto;

        public EmpleadoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<ServiceResponse<Empleado>> AddEmpleado(Empleado empleado)
        {
            var response = new ServiceResponse<Empleado>();
            try
            {
                if (_contexto.Empleados != null)
                {
                    _contexto.Empleados.Add(empleado);
                    await _contexto.SaveChangesAsync();
                    response.Data = (empleado);
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al insertar el empleado {empleado.EmpleadoId}";
                }
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Empleado>> DeleteEmpleado(int id)
        {
            var response = new ServiceResponse<Empleado>();

            try
            {
                if(_contexto.Empleados != null)
                {
                    var empleado = await _contexto.Empleados.FindAsync(id);

                    if(empleado != null)
                    {
                        _contexto.Empleados.Remove(empleado);
                        await _contexto.SaveChangesAsync();
                        response.Data = empleado;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = $"Error al borrar el empleado con el id {id} Posiblemente persona no encontrada";
                    }
                }
            }
            catch(Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Empleado>> GetEmpleado(int id)
        {
            var response = new ServiceResponse<Empleado>();

            try
            {
                if (_contexto.Empleados != null)
                {
                    var empleado = await _contexto.Empleados.FindAsync(id);

                    if(empleado == null)
                    {
                        response.Success = false;
                        response.Message = $"Error, Persona no encontrada con el id:{id}";
                    }
                    else
                    {
                        response.Data = empleado;
                    }
                }
              
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Empleado>>> GetEmpleados()
        {
            var response = new ServiceResponse<List<Empleado>>();

            try
            {
                if (_contexto.Empleados != null)
                {
                    response = new ServiceResponse<List<Empleado>>()
                    {
                        Data = await _contexto.Empleados.ToListAsync()
                    };
                }
                else
                {
                    response.Message = $"Error al buscar la lista de Empleados";
                    response.Success = false;
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Empleado>> ModifyEmpleado(Empleado empleado)
        {
            var response = new ServiceResponse<Empleado>();

            try
            {
                if(_contexto.Empleados != null)
                {
                    _contexto.Entry(empleado).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync();
                    response.Data = empleado;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al modificar la persona con el id{empleado.EmpleadoId}";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
