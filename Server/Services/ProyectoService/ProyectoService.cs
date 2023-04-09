using ProStellar.Shared.Models;
using ProStellar.Shared;
using Microsoft.EntityFrameworkCore;
using ProStellar.Server.DAL;

namespace ProStellar.Server.Services.ProyectoService
{
    public class ProyectoService : IProyectoService
    {
        private Contexto _contexto { get; set; }

        public ProyectoService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Proyecto>> GetProyectoAsync(int Id)
        {
            var response = new ServiceResponse<Proyecto>();
            var Proyecto = await _contexto.Proyectos.FindAsync(Id);
            if (Proyecto == null)
            {
                response.Success = false;
                response.Message = "esta Proyecto  no existe";
            }
            else
            {
                response.Data = Proyecto;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Proyecto>>> GetAllProyectosAsync()
        {
            var response = new ServiceResponse<List<Proyecto>>();
            response.Data = await _contexto.Proyectos.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<Proyecto>> Guardar(Proyecto proyecto)
        {
            if (await Existe(proyecto.ProyectoId))
                return await Modificar(proyecto);
            else
                return await Insertar(proyecto);
        }

        public Task<bool> Existe(int ProyectoId)
        {
            return _contexto.Proyectos.AnyAsync(o => o.ProyectoId == ProyectoId);
        }

        private async Task<ServiceResponse<Proyecto>> Insertar(Proyecto proyecto)
        {
            var response = new ServiceResponse<Proyecto>();

            try
            {
                if (proyecto != null)
                {
                    _contexto.Proyectos.Add(proyecto);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(proyecto).State = EntityState.Detached;

                    response.Data = proyecto;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Proyecto not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = proyecto;
            }

            return response;
        }

        public async Task<ServiceResponse<Proyecto>> Modificar(Proyecto proyecto)
        {
            var response = new ServiceResponse<Proyecto>();
            try
            {
                if (proyecto != null)
                {


                    _contexto.Update(proyecto);
                    var guardo = await _contexto.SaveChangesAsync() > 0;
                    _contexto.Entry(proyecto).State = EntityState.Detached;



                    response.Data = proyecto;
                    response.Success = guardo;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Proyecto not found";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = proyecto;
            }

            return response;

        }
        public async Task<ServiceResponse<Proyecto>> Eliminar(int ProyectoId)
        {
            var response = new ServiceResponse<Proyecto>();
            var Proyecto = await _contexto.Proyectos.FindAsync(ProyectoId);

            try
            {
                if (Proyecto != null)
                {
                    _contexto.Remove(Proyecto);
                    bool guardado = await _contexto.SaveChangesAsync() > 0;

                    response.Data = Proyecto;
                    response.Success = guardado;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Proyecto not found";
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = Proyecto;
            }
            return response;
        }
    }
}

