using Azure;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using ProStellar.Shared;
using ProStellar.Shared.Models;
using static ProStellar.Server.Services.PagoService.PagoService;

namespace ProStellar.Server.Services.PagoService
{
    public class PagoService : IPagoService
    {
        private Contexto _contexto { get; set; }

        public PagoService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Pago>> GetPagoAsync(int Id)
        {
            var response = new ServiceResponse<Pago>();
            var Pago = await _contexto.Pagos.Include("PagoDetalle").AsNoTracking().SingleOrDefaultAsync(o => o.PagoId == Id);
            if (Pago == null)
            {
                response.Success = false;
                response.Message = "esta Pago  no existe";
            }
            else
            {
                response.Data = Pago;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Pago>>> GetAllPagosAsync()
        {
            var response = new ServiceResponse<List<Pago>>();
            response.Data = await _contexto.Pagos.ToListAsync();
            return response;
        }


        public async Task<ServiceResponse<Pago>> Guardar(Pago Pago)
        {
            if (await Existe(Pago.PagoId))
                return await Modificar(Pago);
            else
                return await Insertar(Pago);
        }

        public Task<bool> Existe(int PagoId)
        {
            return _contexto.Pagos.AnyAsync(o => o.PagoId == PagoId);
        }

        private async Task<ServiceResponse<Pago>> Insertar(Pago Pago)
        {
            var response = new ServiceResponse<Pago>();
            try
            {
                if (Pago != null)
                {
                    foreach(var Detalles in Pago.Detalles)
                    {
                        
                    }

                    _contexto.Pagos.Add(Pago);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(Pago).State = EntityState.Detached;
                    response.Data = Pago;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Pago not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Pago;
            }
            return response;
        }

        public async Task<ServiceResponse<Pago>> Modificar(Pago Pago)
        {
            var response = new ServiceResponse<Pago>();
            try
            {
                if (Pago != null)
                {
                    //eliminamos los detalles de la Pago
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM PagoDetalle WHERE PagoId={Pago.PagoId};");

                    //Agregamos los nuevos detalles
                    foreach (var Detalle in Pago.Detalles)
                    {
                        _contexto.Entry(Detalle).State = EntityState.Added;


                    }
                    //actualizamos la Pago
                    _contexto.Update(Pago);
                    var guardo = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(Pago).State = EntityState.Detached;

                    response.Data = Pago;
                    response.Success = guardo;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Pago not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Pago;
            }
            return response;
        }
        public async Task<ServiceResponse<Pago>> Eliminar(int PagoId)
        {
            var response = new ServiceResponse<Pago>();
            var Pago = await _contexto.Pagos.Include("PagoDetalle").AsNoTracking().SingleOrDefaultAsync(o => o.PagoId == PagoId);
            try
            {
                if (Pago != null)
                {
                    _contexto.Remove(Pago);
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM Pagos WHERE PagoId={PagoId};");
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    response.Data = Pago;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Pago not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Pago;
            }
            return response;
        }
    }
}
