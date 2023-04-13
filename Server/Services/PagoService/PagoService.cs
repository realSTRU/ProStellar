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
            foreach (var pago in _contexto.Pagos.Include("Detalles").AsNoTracking())
            {
                await Modificar(pago);
            }

            var Pago = await _contexto.Pagos.Include("Detalles").AsNoTracking().SingleOrDefaultAsync(o => o.PagoId == Id);

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
            foreach (var pago in _contexto.Pagos.Include("Detalles").AsNoTracking())
            {
                await Modificar(pago);
            }
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
                var Nomina = await _contexto.Nominas.Include("Detalles").AsNoTracking().SingleOrDefaultAsync(o => o.NominaId == Pago.NominaId);
                if (Pago != null && Nomina != null)
                {
                    foreach (var Detalle in Pago.Detalles)
                    {
                        foreach (var DNomina in Nomina.Detalles)
                        {
                            if (DNomina.NominaDetalleId == Detalle.NominaDetalleId)
                            {
                                DNomina.Balance -= Detalle.ValorPagado;

                            }
                        }
                    }
                    //actualizamos la nomina con su nuevo balance
                    _contexto.Nominas.Update(Nomina);
                    //Agregamos el pago
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
            if (Pago.Detalles.Count() <= 0)
            {
                return await Eliminar(Pago.PagoId);
            }
            else
            {
                var response = new ServiceResponse<Pago>();
                try
                {
                    if (Pago != null)
                    {
                        //eliminamos  los detalles de la Pago y aumentamos el balance
                        var Nomina = await _contexto.Nominas.Include("Detalles").AsNoTracking().SingleOrDefaultAsync(o => o.NominaId == Pago.NominaId);
                        var Anterior = await _contexto.Pagos.Include("Detalles").AsNoTracking().SingleOrDefaultAsync(o => o.PagoId == Pago.PagoId);
                        if (Nomina != null && Anterior != null)
                        {
                            foreach (var Detalle in Anterior.Detalles)
                            {
                                foreach (var DNomina in Nomina.Detalles)
                                {
                                    if (DNomina.NominaDetalleId == Detalle.NominaDetalleId)
                                    {
                                        DNomina.Balance += Detalle.ValorPagado;
                                    }
                                }
                            }
                            _contexto.Nominas.Update(Nomina);
                            _contexto.Database.ExecuteSqlRaw($"DELETE FROM PagoDetalle WHERE PagoId={Pago.PagoId};");
                            //Agregamos los nuevos detalles y disminuimos el balance
                            foreach (var Detalle in Pago.Detalles)
                            {
                                foreach (var DNomina in Nomina.Detalles)
                                {
                                    if (DNomina.NominaDetalleId == Detalle.NominaDetalleId)
                                    {
                                        DNomina.Balance -= Detalle.ValorPagado;
                                    }
                                }
                                _contexto.Entry(Detalle).State = EntityState.Added;
                            }

                            //actualizamos el monto
                            Pago.Monto = Pago.Detalles.Select(o => o.ValorPagado).Sum();

                            //actualizamos la Nomina
                            _contexto.Nominas.Update(Nomina);
                        }
                        //actualizamos el pago
                        _contexto.Pagos.Update(Pago);
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
        }
        public async Task<ServiceResponse<Pago>> Eliminar(int PagoId)
        {
            var response = new ServiceResponse<Pago>();
            try
            {
                var Pago = await _contexto.Pagos.Include("Detalles").AsNoTracking().SingleOrDefaultAsync(o => o.PagoId == PagoId);
                if (Pago != null)
                {
                    var Nomina = await _contexto.Nominas.Include("Detalles").AsNoTracking().SingleOrDefaultAsync(o => o.NominaId == Pago.NominaId);
                    if (Nomina != null)
                    {
                        foreach (var Detalle in Pago.Detalles)
                        {
                            foreach (var DNomina in Nomina.Detalles)
                            {
                                if (DNomina.NominaDetalleId == Detalle.NominaDetalleId)
                                {
                                    DNomina.Balance += Detalle.ValorPagado;
                                }
                            }
                        }
                        _contexto.Nominas.Update(Nomina);
                        _contexto.RemoveRange(Pago.Detalles);
                        _contexto.Remove(Pago);
                    }
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    response.Data = Pago;
                    response.Success = guardado;
                    _contexto.Entry(Pago).State = EntityState.Detached;
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
            }
            return response;
        }
    }
}
