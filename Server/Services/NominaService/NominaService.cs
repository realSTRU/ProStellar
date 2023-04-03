using Azure;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using ProStellar.Shared;
using ProStellar.Shared.Models;
using static ProStellar.Server.Services.NominaService.NominaService;

namespace ProStellar.Server.Services.NominaService
{
    public class NominaService : INominaService
    {
        private Contexto _contexto { get; set; }

        public NominaService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Nomina>> GetNominaAsync(int Id)
        {
            var response = new ServiceResponse<Nomina>();
            var Nomina = await _contexto.Nominas.FindAsync(Id);
            if (Nomina == null)
            {
                response.Success = false;
                response.Message = "esta Nomina  no existe";
            }
            else
            {
                response.Data = Nomina;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Nomina>>> GetAllNominasAsync()
        {
            var response = new ServiceResponse<List<Nomina>>();
            response.Data = await _contexto.Nominas.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<Nomina>> Guardar(Nomina Nomina)
        {
            if (await Existe(Nomina.NominaId))
                return await Modificar(Nomina);
            else
                return await Insertar(Nomina);
        }

        public Task<bool> Existe(int NominaId)
        {
            return _contexto.Nominas.AnyAsync(o => o.NominaId == NominaId);
        }

        private async Task<ServiceResponse<Nomina>> Insertar(Nomina Nomina)
        {
            var response = new ServiceResponse<Nomina>();

            try
            {
                if (Nomina != null)
                {
                    _contexto.Nominas.Add(Nomina);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(Nomina).State = EntityState.Detached;

                    response.Data = Nomina;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Nomina not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Nomina;
            }

            return response;
        }

        public async Task<ServiceResponse<Nomina>> Modificar(Nomina Nomina)
        {
            var response = new ServiceResponse<Nomina>();
            try
            {
                if (Nomina != null)
                {


                    _contexto.Update(Nomina);
                    var guardo = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(Nomina).State = EntityState.Detached;



                    response.Data = Nomina;
                    response.Success = guardo;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Nomina not found";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Nomina;
            }

            return response;

        }
        public async Task<ServiceResponse<Nomina>> Eliminar(int NominaId)
        {
            var response = new ServiceResponse<Nomina>();
            var Nomina = await _contexto.Nominas.FindAsync(NominaId);

            try
            {
                if (Nomina != null)
                {
                    _contexto.Remove(Nomina);
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM Nominas WHERE NominaId={NominaId};");
                    bool guardado = await _contexto.SaveChangesAsync() > 0;

                    response.Data = Nomina;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Nomina not found";
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Nomina;
            }

            return response;


        }
    }
}
