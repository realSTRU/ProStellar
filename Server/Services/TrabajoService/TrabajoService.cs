using Azure;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using ProStellar.Shared;
using ProStellar.Shared.Models;
using static ProStellar.Server.Services.TrabajoService.TrabajoService;

namespace ProStellar.Server.Services.TrabajoService
{
    public class TrabajoService : ITrabajoService
    {
        private Contexto _contexto { get; set; }

        public TrabajoService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Trabajo>> GetTrabajoAsync(int Id)
        {
            var response = new ServiceResponse<Trabajo>();
            var Trabajo = await _contexto.Trabajos.FindAsync(Id);
            if (Trabajo == null)
            {
                response.Success = false;
                response.Message = "esta Trabajo  no existe";
            }
            else
            {
                response.Data = Trabajo;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Trabajo>>> GetAllTrabajosAsync()
        {
            var response = new ServiceResponse<List<Trabajo>>();
            response.Data = await _contexto.Trabajos.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<Trabajo>> Guardar(Trabajo Trabajo)
        {
            if (await Existe(Trabajo.TrabajoId))
                return await Modificar(Trabajo);
            else
                return await Insertar(Trabajo);
        }

        public Task<bool> Existe(int TrabajoId)
        {
            return _contexto.Trabajos.AnyAsync(o => o.TrabajoId == TrabajoId);
        }

        private async Task<ServiceResponse<Trabajo>> Insertar(Trabajo trabajo)
        {
            var response = new ServiceResponse<Trabajo>();

            try
            {
                if (trabajo != null)
                {
                    _contexto.Trabajos.Add(trabajo);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(trabajo).State = EntityState.Detached;

                    response.Data = trabajo;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Trabajo not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = trabajo;
            }

            return response;
        }

        public async Task<ServiceResponse<Trabajo>> Modificar(Trabajo trabajo)
        {
            var response = new ServiceResponse<Trabajo>();
            try
            {
                if (trabajo != null)
                {


                    _contexto.Update(trabajo);
                    var guardo = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(trabajo).State = EntityState.Detached;



                    response.Data = trabajo;
                    response.Success = guardo;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Trabajo not found";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = trabajo;
            }

            return response;

        }
        public async Task<ServiceResponse<Trabajo>> Eliminar(int TrabajoId)
        {
            var response = new ServiceResponse<Trabajo>();
            var trabajo = await _contexto.Trabajos.FindAsync(TrabajoId);

            try
            {
                if (trabajo != null)
                {
                    _contexto.Remove(trabajo);
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM Trabajos WHERE TrabajoId={TrabajoId};");
                    bool guardado = await _contexto.SaveChangesAsync() > 0;

                    response.Data = trabajo;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Trabajo not found";
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = trabajo;
            }

            return response;


        }
    }
}
