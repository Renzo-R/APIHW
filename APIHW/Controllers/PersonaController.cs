using APIHW.Data;
using APIHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PersonaController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet("BuscarPersona")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _uow.PersonaService.ObtenerEntidad(id);
            if (persona == null)
            {
                return BadRequest("Persona no encontrada");
            }
            return Ok(persona);
        }
        [HttpGet("ObtenerTodasPersonas")]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _uow.PersonaService.ObtenerTodoEntidades();
            if (personas == null)
            {
                return BadRequest("No hay Personas");
            }
            return Ok(personas);
        }
        [HttpGet("ObtenerPersonas")]
        public async Task<IActionResult> Get()
        {
            var personas = await _uow.PersonaService.ObtenerEntidades();
            if (personas == null)
            {
                return BadRequest("No hay Personas Activas");
            }
            return Ok(personas);
        }
        [HttpPost("AgregarPersona")]
        public async Task<IActionResult> AgregarPersona(PersonaDTO p)
        {
            var personas = await _uow.PersonaService.AgregarPersona(p);
            if (personas == null)
            {
                return BadRequest("Equipo al que desea agregar persona no existe o no esta activo");
            }
            await _uow.SaveAsync();
            return Ok(await _uow.PersonaService.ObtenerEntidades());
        }
        [HttpPut("ActualizarPersona")]
        public async Task<IActionResult> ActualizarPersona(int id, PersonaDTO personaupdt)
        {
            var persona = await _uow.PersonaService.ObtenerEntidad(id);
            if (persona == null || !persona.Active)
            {
                return BadRequest("Persona no encontrada o no activa");
            }
            await _uow.PersonaService.ActualizarPersona(persona, personaupdt);
            await _uow.SaveAsync();
            return Ok(await _uow.PersonaService.ObtenerEntidades());
        }
        [HttpDelete("BorrarPersona")]
        public async Task<IActionResult> BorrarPersona(int id)
        {
            var personadel = await _uow.PersonaService.ObtenerEntidad(id);
            if (personadel == null || !personadel.Active)
            {
                return BadRequest("Persona no encontradao no activa");
            }
            await _uow.PersonaService.BorrarPersona(personadel);
            await _uow.SaveAsync();
            return Ok(await _uow.PersonaService.ObtenerEntidades());
        }
        [HttpGet("ObtenerPersonasPorIdEquipo")]
        public async Task<IActionResult> GetPersonasPorIdEquipo(int id)
        {
            var personas = await _uow.PersonaService.ObtenerPersonasPorEquipo(id);
            if (personas == null)
            {
                return BadRequest("El equipo a consultar no existe");
            }
            else if (personas.Count == 0)
            {
                return BadRequest("No hay Personas Activas en el Equipo " + id);
            }
            return Ok(personas);
        }
        [HttpGet("ObtenerPersonasPorColor")]
        public async Task<IActionResult> GetPersonasPorColor(string color)
        {
            var personas = await _uow.PersonaService.ObtenerPersonasPorColor(color);
            if (personas == null)
            {
                return BadRequest("El color a consultar no existe");
            }
            else if (personas.Count == 0)
            {
                return BadRequest("No hay Personas Activas con el color " + color);
            }
            return Ok(personas);
        }
        [HttpGet("ObtenerPersonasPorDistrito")]
        public async Task<IActionResult> GetPersonasPorDistrito(string distrito)
        {
            var personas = await _uow.PersonaService.ObtenerPersonasPorDistrito(distrito);
            if (personas == null)
            {
                return BadRequest("El distrito a consultar no existe");
            }
            else if (personas.Count == 0)
            {
                return BadRequest("No hay Personas Activas que vivan en " + distrito);
            }
            return Ok(personas);
        }
        [HttpGet("ObtenerPersonasEdadDescendente")]
        public async Task<IActionResult> GetPersonasEdadDescendente()
        {
            var personas = await _uow.PersonaService.ObtenerPersonasEdadDescendente();
            if (personas.Count == 0)
            {
                return BadRequest("No hay Personas Activas o no se han agregado");
            }
            return Ok(personas);
        }
    }
}
