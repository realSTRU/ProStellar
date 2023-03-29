using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.TrabajoService;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly ITrabajoService TrabajoServices;
        public TrabajoController(ITrabajoService TrabajoService)
        {
            this.TrabajoServices = TrabajoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Trabajo>>>> GetAllTrabajos()
        {
            var productos = await TrabajoServices.GetAllTrabajosAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Trabajo>>> GetTrabajo(int ID)
        {
            var result = await TrabajoServices.GetTrabajoAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Trabajo>>> Guardar(Trabajo Trabajo)
        {
            var result = await TrabajoServices.Guardar(Trabajo);
            return Ok(result);
        }

        [HttpDelete("{TrabajoId}")]
        public async Task<ActionResult<ServiceResponse<Trabajo>>> Eliminar(int TrabajoId)
        {
            var result = await TrabajoServices.Eliminar(TrabajoId);
            return Ok(result);
        }
    }
}
