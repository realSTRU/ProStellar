using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using System.Linq.Expressions;

namespace ProStellar.Server.Services.TrabajoServices
{
    public class TrabajoService : ITrabajoService
    {
        private readonly Contexto _contexto;

        public TrabajoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<ServiceResponse<Trabajo>> AddTrabajo(Trabajo trabajo)
        {
            var response = new ServiceResponse<Trabajo>();

            try
            {
                if(_contexto.Trabajos != null)
                {
                    _contexto.Trabajos.Add(trabajo);
                    await _contexto.SaveChangesAsync();
                    response.Data = trabajo;
                }
                else
                {
                    response.Message = $"Error al guardar trabajo con el id:{trabajo.TrabajoId}";
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

        public async Task<ServiceResponse<Trabajo>> DeleteTrabajo(int id)
        {
            var response = new ServiceResponse<Trabajo>();

            try
            {
                if(_contexto.Trabajos != null)
                {
                    var trabajo = await _contexto.Trabajos.FindAsync(id);
                    await _contexto.SaveChangesAsync();
                    response.Data = trabajo;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al eliminar el trabajo con el id:{id}";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Trabajo>> GetTrabajo(int id)
        {
            var response = new ServiceResponse<Trabajo>();

            try
            {
                if (_contexto.Trabajos != null)
                {
                    var trabajo = await _contexto.Trabajos.FindAsync(id);

                    if (trabajo == null)
                    {
                        response.Success = false;
                        response.Message = $"Error, Persona con el id:{id} no encontrada";
                    }
                    else
                    {
                        response.Data = trabajo;
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

        public async Task<ServiceResponse<List<Trabajo>>> GetTrabajos()
        {
            var response = new ServiceResponse<List<Trabajo>>();

            try
            { 
                if(_contexto.Trabajos != null)
                {
                    response = new ServiceResponse<List<Trabajo>>()
                    {
                        Data = await _contexto.Trabajos.ToListAsync()
                    };
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al buscar la lista de trabajos";
                }
            }
            catch(Exception ex )
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<ServiceResponse<Trabajo>> ModifyTrabajo(Trabajo trabajo)
        {
            var response = new ServiceResponse<Trabajo>();

            try
            {
                if(_contexto.Trabajos != null)
                {
                    _contexto.Entry(trabajo).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync();
                    response.Data = trabajo;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al modificar el trabajo con el id {trabajo.TrabajoId}";

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
