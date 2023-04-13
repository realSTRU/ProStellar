using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.PagoService;
using ProStellar.Shared;
using ProStellar.Shared.Models;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Pago>>>> GetAllPays()
        {
            var result = await _pagoService.GetAllPagosAsync();

            if (result != null && result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("{PagoId}")]
        public async Task<ActionResult<ServiceResponse<Pago>>> GetPay(int PagoId)
        {
            var result = await _pagoService.GetPagoAsync(PagoId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Pago>>> SavePay(Pago pago)
        {
            var result = await _pagoService.Guardar(pago);

            if (result.Success != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{PagoId}")]
        public async Task<ActionResult<ServiceResponse<Pago>>> DeletePay(int PagoId)
        {
            var result = await _pagoService.Eliminar(PagoId);

            if (result.Success != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
