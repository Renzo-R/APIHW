using APIHW.Data;
using APIHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIHW.Controllers
{
    public class EquipoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public EquipoController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet("BuscarEquipo")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipo = await _uow.EquipoService.ObtenerEntidad(id);
            if (equipo == null)
            {
                return BadRequest("Equipo no encontrado");
            }
            return Ok(equipo);
        }
        [HttpGet("ObtenerTodosEquipos")]
        public async Task<IActionResult> GetAll()
        {
            var equipos = await _uow.EquipoService.ObtenerTodoEntidades();
            if (equipos == null)
            {
                return BadRequest("No hay Equipos");
            }
            return Ok(equipos);
        }
        [HttpGet("ObtenerEquipos")]
        public async Task<IActionResult> Get()
        {
            var equipos = await _uow.EquipoService.ObtenerEntidades();
            if (equipos == null)
            {
                return BadRequest("No hay Equipos Activos");
            }
            return Ok(equipos);
        }
        [HttpPost("AgregarEquipo")]
        public async Task<IActionResult> AgregarEquipo(EquipoDTO eq)
        {
            await _uow.EquipoService.AgregarEquipo(eq);
            await _uow.SaveAsync();
            return Ok(await _uow.EquipoService.ObtenerEntidades());
        }
        [HttpPut("ActualizarEquipo")]
        public async Task<IActionResult> ActualizarEquipos(int id, EquipoDTO equiupdt)
        {
            var equipo = await _uow.EquipoService.ObtenerEntidad(id);
            if (equipo == null)
            {
                return BadRequest("Equipo no encontrado");
            }
            else if (!equipo.Active)
            {
                return BadRequest("Equipo no activo");
            }
            await _uow.EquipoService.ActualizarEquipo(equipo, equiupdt);
            await _uow.SaveAsync();
            return Ok(await _uow.EquipoService.ObtenerEntidades());
        }
        [HttpDelete("BorrarEquipo")]
        public async Task<IActionResult> BorrarEquipo(int id)
        {
            var equidel = await _uow.EquipoService.ObtenerEntidad(id);
            if (equidel == null)
            {
                return BadRequest("Equipo no encontrado");
            }
            else if (!equidel.Active)
            {
                return BadRequest("Equipo no activo");
            }
            await _uow.EquipoService.BorrarEquipo(equidel);
            await _uow.SaveAsync();
            return Ok(await _uow.EquipoService.ObtenerEntidades());
        }
    }
}
