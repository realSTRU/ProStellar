using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Server.Services.TipoPagoServices;
using System.Threading.Tasks.Sources;
using ProStellar.Shared.Models;
using ProStellar.Shared;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController : ControllerBase
    {
        private readonly ITipoPagoService _tipoPagoService;

        public TipoPagoController(ITipoPagoService tipoPagoService)
        {
            _tipoPagoService = tipoPagoService;
        }

        [HttpGet("{TipoPagoId}")]
        public async Task<ActionResult<ServiceResponse<TipoPago>>> FindTipoPago(int TipoPagoId)
        {
            var result = await _tipoPagoService.GetTipoPago(TipoPagoId);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<TipoPago>>> GetListTipoPagos()
        {
            var result = await _tipoPagoService.GetTiposPagos();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TipoPago>>> SaveTipoPago(TipoPago tipoPago)
        {
            var result = await _tipoPagoService.SaveTipoPago(tipoPago);

            if (result.Success != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TipoPago>>> ModifyTipoPago(TipoPago tipoPago)
        {
            var result = await _tipoPagoService.ModifyTipoPago(tipoPago);

            if (result.Success != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{TipoPagoId}")]
        public async Task<ActionResult<ServiceResponse<TipoPago>>> DeleteTipoPago(int TipoPagoId)
        {
            var result = await _tipoPagoService.DeleteTipoPago(TipoPagoId);

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
