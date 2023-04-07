using Microsoft.EntityFrameworkCore;
using ProStellar.Shared.Models;
using ProStellar.Shared;
using ProStellar.Server.DAL;

namespace ProStellar.Server.Services.TipoPagoServices
{
    public class TipoPagoService : ITipoPagoService

    {
        private readonly Contexto _contexto;
        public TipoPagoService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<ServiceResponse<TipoPago>> AddTipoPago(TipoPago tipoPago)
        {
            var response = new ServiceResponse<TipoPago>();
            try
            {
                if (_contexto.TiposPagos != null)
                {
                    _contexto.TiposPagos.Add(tipoPago);
                    await _contexto.SaveChangesAsync();
                    response.Data = tipoPago;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al guardar TipoPago con el id:{tipoPago.TipoPagoId}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<TipoPago>> GetTipoPago(int id)
        {
            var response = new ServiceResponse<TipoPago>();
            try
            {
                if (_contexto.TiposPagos != null)
                {
                    var tipoPago = await _contexto.TiposPagos.FindAsync(id);
                    if (tipoPago == null)
                    {
                        response.Success = false;
                        response.Message = $"Error al buscar, no se ha encontrado el TipoPago con el id:{id}";
                    }
                    else
                    {
                        response.Data = tipoPago;
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error en la base de datos";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<TipoPago>>> GetTiposPagos()
        {
            var response = new ServiceResponse<List<TipoPago>>();
            try
            {
                if (_contexto.TiposPagos != null)
                {
                    response = new ServiceResponse<List<TipoPago>>()
                    {
                        Data = await _contexto.TiposPagos.ToListAsync()
                    };
                }
                else
                {
                    response.Message = $"Error al devolver la lista de TiposPagos";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<TipoPago>> DeleteTipoPago(int id)
        {
            var response = new ServiceResponse<TipoPago>();

            try
            {
                if (_contexto.TiposPagos != null)
                {
                    var tipoPago = await _contexto.TiposPagos.FindAsync(id);
                    if (tipoPago != null)
                    {
                        _contexto.TiposPagos.Remove(tipoPago);
                        await _contexto.SaveChangesAsync();
                        response.Data = tipoPago;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = $"Error al eliminar,No encontrado TipoPago con el id:{id}";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al borrar el TipoPago, PROBLEMAS EN LA DATABASE";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<TipoPago>> ModifyTipoPago(TipoPago tipoPago)
        {
            var response = new ServiceResponse<TipoPago>();

            try
            {
                if (_contexto.TiposPagos != null)
                {
                    _contexto.Entry(tipoPago).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync();
                    response.Data = tipoPago;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al editar el TipoPago con el id :{tipoPago.TipoPagoId}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<bool> Existe(int Id)
        {
            return await _contexto.TiposPagos.AnyAsync(t => t.TipoPagoId == Id);
        }

        public async Task<ServiceResponse<TipoPago>> SaveTipoPago(TipoPago tipoPago)
        {
            if (await Existe(tipoPago.TipoPagoId))
            {
                return await ModifyTipoPago(tipoPago);
            }
            else
            {
                return await AddTipoPago(tipoPago);
            }
        }
    }
}
