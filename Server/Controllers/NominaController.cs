using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.NominaService;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {
        private readonly INominaService NominaServices;
        public NominaController(INominaService NominaService)
        {
            this.NominaServices = NominaService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Nomina>>>> GetAllNominas()
        {
            var nominas = await NominaServices.GetAllNominasAsync();
            return Ok(nominas);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Nomina>>> GetNomina(int ID)
        {
            var result = await NominaServices.GetNominaAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Nomina>>> Guardar(Nomina Nomina)
        {
            var result = await NominaServices.Guardar(Nomina);
            return Ok(result);
        }

        [HttpDelete("{NominaId}")]
        public async Task<ActionResult<ServiceResponse<Nomina>>> Eliminar(int NominaId)
        {
            var result = await NominaServices.Eliminar(NominaId);
            return Ok(result);
        }
    }
}
