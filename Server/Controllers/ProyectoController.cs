using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.ProyectoService;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoService ProyectoServices;
        public ProyectoController(IProyectoService ProyectoService)
        {
            this.ProyectoServices = ProyectoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Proyecto>>>> GetAllProyectos()
        {
            var productos = await ProyectoServices.GetAllProyectosAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Proyecto>>> GetProyecto(int ID)
        {
            var result = await ProyectoServices.GetProyectoAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Proyecto>>> Guardar(Proyecto Proyecto)
        {
            var result = await ProyectoServices.Guardar(Proyecto);
            return Ok(result);
        }

        [HttpDelete("{ProyectoId}")]
        public async Task<ActionResult<ServiceResponse<Proyecto>>> Eliminar(int ProyectoId)
        {
            var result = await ProyectoServices.Eliminar(ProyectoId);
            return Ok(result);
        }
    }
}
