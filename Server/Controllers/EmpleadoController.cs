using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProStellar.Shared.Models;
using ProStellar.Shared;
using ProStellar.Server.Services.EmpleadoServices;

namespace ProStellar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("{EmpleadoId}")]
        public async Task<ActionResult<ServiceResponse<Empleado>>> FindEmpleado(int EmpleadoId)
        {
            var result = await _empleadoService.GetEmpleado(EmpleadoId);

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
        public async Task<ActionResult<ServiceResponse<Empleado>>> GetListEmpleados()
        {
            var result = await _empleadoService.GetEmpleados();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Empleado>>> InsertEmpleado(Empleado empleado)
        {
            var result = await _empleadoService.AddEmpleado(empleado);

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
        public async Task<ActionResult<ServiceResponse<Empleado>>> ModifyEmpleado(Empleado empleado)
        {
            var result = await _empleadoService.ModifyEmpleado(empleado);

            if (result.Success != false)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{EmpleadoId}")]
        public async Task<ActionResult<ServiceResponse<Empleado>>> DeleteEmpledo(int EmpleadoId)
        {
            var result = await _empleadoService.DeleteEmpleado(EmpleadoId);

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
