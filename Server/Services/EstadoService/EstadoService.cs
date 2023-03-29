using Azure;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using ProStellar.Shared;
using ProStellar.Shared.Models;
using static ProStellar.Server.Services.EstadoService.EstadoService;

namespace ProStellar.Server.Services.EstadoService
{
    public class EstadoService : IEstadoService
    {
        private Contexto _contexto { get; set; }

        public EstadoService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Estado>> GetEstadoAsync(int Id)
        {
            var response = new ServiceResponse<Estado>();
            var Estado = await _contexto.Estados.FindAsync(Id);
            if (Estado == null)
            {
                response.Success = false;
                response.Message = "esta Estado  no existe";
            }
            else
            {
                response.Data = Estado;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Estado>>> GetAllEstadosAsync()
        {
            var response = new ServiceResponse<List<Estado>>();
            response.Data = await _contexto.Estados.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<Estado>> Guardar(Estado estado)
        {
            if (await Existe(estado.EstadoId))
                return await Modificar(estado);
            else
                return await Insertar(estado);
        }

        public Task<bool> Existe(int EstadoId)
        {
            return _contexto.Estados.AnyAsync(o => o.EstadoId == EstadoId);
        }

        private async Task<ServiceResponse<Estado>> Insertar(Estado estado)
        {
            var response = new ServiceResponse<Estado>();

            try
            {
                if (estado != null)
                {
                    _contexto.Estados.Add(estado);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(estado).State = EntityState.Detached;

                    response.Data = estado;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Estado not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = estado;
            }

            return response;
        }

        public async Task<ServiceResponse<Estado>> Modificar(Estado estado)
        {
            var response = new ServiceResponse<Estado>();
            try
            {
                if (estado != null)
                {


                    _contexto.Update(estado);
                    var guardo = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(estado).State = EntityState.Detached;



                    response.Data = estado;
                    response.Success = guardo;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Estado not found";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = estado;
            }

            return response;

        }
        public async Task<ServiceResponse<Estado>> Eliminar(int EstadoId)
        {
            var response = new ServiceResponse<Estado>();
            var Estado = await _contexto.Estados.FindAsync(EstadoId);

            try
            {
                if (Estado != null)
                {
                    _contexto.Remove(Estado != null);
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM Estados WHERE EstadoId={EstadoId};");
                    bool guardado = await _contexto.SaveChangesAsync() > 0;

                    response.Data = Estado;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Estado not found";
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Estado;
            }

            return response;


        }
    }
}
