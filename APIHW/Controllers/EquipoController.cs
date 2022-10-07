using APIHW.Data;
using APIHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIHW.Controllers
{
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _service;
        public EquipoController(IEquipoService service)
        {
            _service = service;
        }
        [HttpGet("BuscarEquipo")]
        public async Task<IActionResult> Get(int id)
        {
            var equipo = await _service.ObtenerEntidad(id);
            if (equipo == null)
            {
                return BadRequest("Equipo no encontrado");
            }
            return Ok(equipo);
        }
        [HttpGet("ObtenerTodosEquipos")]
        public async Task<IActionResult> GetAll()
        {
            var equipos = await _service.ObtenerTodoEntidades();
            if (equipos == null)
            {
                return BadRequest("No hay Equipos");
            }
            return Ok(equipos);
        }
        [HttpGet("ObtenerEquipos")]
        public async Task<IActionResult> Get()
        {
            var equipos = await _service.ObtenerEntidades();
            if (equipos == null)
            {
                return BadRequest("No hay Equipos Activos");
            }
            return Ok(equipos);
        }
        [HttpPost("AgregarEquipo")]
        public async Task<IActionResult> AgregarEquipo(EquipoDTO eq)
        {
            return Ok(await _service.AgregarEquipo(eq));
        }
        [HttpPut("ActualizarEquipo")]
        public async Task<IActionResult> ActualizarEquipos(int id, EquipoDTO equiupdt)
        {
            var equipo = await _service.ObtenerEntidad(id);
            if (equipo == null)
            {
                return BadRequest("Equipo no encontrado");
            }
            await _service.ActualizarEquipo(equipo, equiupdt);
            return Ok(await _service.ObtenerEntidades());
        }
        [HttpDelete("BorrarEquipo")]
        public async Task<IActionResult> BorrarEquipo(int id)
        {
            var equidel = await _service.ObtenerEntidad(id);
            if (equidel == null)
            {
                return BadRequest("Persona no encontrada");
            }
            return Ok(await _service.BorrarEquipo(equidel));
        }
    }
}
