
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.CantidadService;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantidadController : ControllerBase
    {
        private readonly ICantidadService CantidadServices;
        public CantidadController(ICantidadService CantidadService)
        {
            this.CantidadServices = CantidadService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Cantidad>>>> GetAllCantidades()
        {
            var productos = await CantidadServices.GetAllCantidadsAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Cantidad>>> GetCantidad(int ID)
        {
            var result = await CantidadServices.GetCantidadAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Cantidad>>> Guardar(Cantidad Cantidad)
        {
            var result = await CantidadServices.Guardar(Cantidad);
            return Ok(result);
        }

        [HttpDelete("{CantidadId}")]
        public async Task<ActionResult<ServiceResponse<Cantidad>>> Eliminar(int CantidadId)
        {
            var result = await CantidadServices.Eliminar(CantidadId);
            return Ok(result);
        }
    }
}
