using Azure;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;
using ProStellar.Shared;
using ProStellar.Shared.Models;
using static ProStellar.Server.Services.CantidadService.CantidadService;

namespace ProStellar.Server.Services.CantidadService
{
    public class CantidadService : ICantidadService
    {
        private Contexto _contexto { get; set; }

        public CantidadService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Cantidad>> GetCantidadAsync(int Id)
        {
            var response = new ServiceResponse<Cantidad>();
            var Cantidad = await _contexto.Cantidades.FindAsync(Id);
            if (Cantidad == null)
            {
                response.Success = false;
                response.Message = "esta Cantidad  no existe";
            }
            else
            {
                response.Data = Cantidad;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Cantidad>>> GetAllCantidadsAsync()
        {
            var response = new ServiceResponse<List<Cantidad>>();
            response.Data = await _contexto.Cantidades.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<Cantidad>> Guardar(Cantidad cantidad)
        {
            if (await Existe(cantidad.CantidadId))
                return await Modificar(cantidad);
            else
                return await Insertar(cantidad);
        }

        public Task<bool> Existe(int CantidadId)
        {
            return _contexto.Cantidades.AnyAsync(o => o.CantidadId == CantidadId);
        }

        private async Task<ServiceResponse<Cantidad>> Insertar(Cantidad cantidad)
        {
            var response = new ServiceResponse<Cantidad>();

            try
            {
                if (cantidad != null)
                {
                    _contexto.Cantidades.Add(cantidad);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(cantidad).State = EntityState.Detached;

                    response.Data = cantidad;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Cantidad not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = cantidad;
            }

            return response;
        }

        public async Task<ServiceResponse<Cantidad>> Modificar(Cantidad cantidad)
        {
            var response = new ServiceResponse<Cantidad>();
            try
            {
                if (cantidad != null)
                {


                    _contexto.Update(cantidad);
                    var guardo = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(cantidad).State = EntityState.Detached;



                    response.Data = cantidad;
                    response.Success = guardo;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Cantidad not found";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = cantidad;
            }

            return response;

        }
        public async Task<ServiceResponse<Cantidad>> Eliminar(int CantidadId)
        {
            var response = new ServiceResponse<Cantidad>();
            var Cantidad = await _contexto.Cantidades.FindAsync(CantidadId);

            try
            {
                if (Cantidad != null)
                {
                    _contexto.Remove(Cantidad);
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM Cantidads WHERE CantidadId={CantidadId};");
                    bool guardado = await _contexto.SaveChangesAsync() > 0;

                    response.Data = Cantidad;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Cantidad not found";
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Cantidad;
            }

            return response;


        }
    }
}
