using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.EstadoService;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService EstadoServices;
        public EstadoController(IEstadoService EstadoService)
        {
            this.EstadoServices = EstadoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Estado>>>> GetAllEstados()
        {
            var productos = await EstadoServices.GetAllEstadosAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Estado>>> GetEstado(int ID)
        {
            var result = await EstadoServices.GetEstadoAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Estado>>> Guardar(Estado Estado)
        {
            var result = await EstadoServices.Guardar(Estado);
            return Ok(result);
        }

        [HttpDelete("{EstadoId}")]
        public async Task<ActionResult<ServiceResponse<Estado>>> Eliminar(int EstadoId)
        {
            var result = await EstadoServices.Eliminar(EstadoId);
            return Ok(result);
        }
    }
}
