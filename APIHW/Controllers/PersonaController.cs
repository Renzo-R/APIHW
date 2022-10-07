using APIHW.Data;
using APIHW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _service;
        public PersonaController(IPersonaService service)
        {
            _service = service;
        }
        [HttpGet("BuscarPersona")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _service.ObtenerEntidad(id);
            if (persona == null)
            {
                return BadRequest("Persona no encontrado");
            }
            return Ok(persona);
        }
        [HttpGet("ObtenerTodasPersonas")]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _service.ObtenerTodoEntidades();
            if (personas == null)
            {
                return BadRequest("No hay Personas");
            }
            return Ok(personas);
        }
        [HttpGet("ObtenerPersonas")]
        public async Task<IActionResult> Get()
        {
            var personas = await _service.ObtenerEntidades();
            if (personas == null)
            {
                return BadRequest("No hay Personas Activas");
            }
            return Ok(personas);
        }
        [HttpPost("AgregarPersona")]
        public async Task<IActionResult> AgregarPersona(PersonaDTO p)
        {
            var personas = await _service.AgregarPersona(p);
            if (personas == null)
            {
                return BadRequest("Equipo al que desea agregar persona no existe o no está activo");
            }
            else return Ok(personas);
        }
        [HttpPut("ActualizarPersona")]
        public async Task<IActionResult> ActualizarPersona(int id, PersonaDTO personaupdt)
        {
            var persona = await _service.ObtenerEntidad(id);
            if (persona == null)
            {
                return BadRequest("Persona no encontrada");
            }
            await _service.ActualizarPersona(persona, personaupdt);
            return Ok(await _service.ObtenerEntidades());
        }
        [HttpDelete("BorrarPersona")]
        public async Task<IActionResult> BorrarPersona(int id)
        {
            var personadel = await _service.ObtenerEntidad(id);
            if (personadel == null)
            {
                return BadRequest("Persona no encontrada");
            }
            return Ok(await _service.BorrarPersona(personadel));
        }
        [HttpGet("ObtenerPersonasPorIdEquipo")]
        public async Task<IActionResult> GetPersonasPorIdEquipo(int id)
        {
            var personas = await _service.ObtenerPersonasPorEquipo(id);
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
            var personas = await _service.ObtenerPersonasPorColor(color);
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
            var personas = await _service.ObtenerPersonasPorDistrito(distrito);
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
            var personas = await _service.ObtenerPersonasEdadDescendente();
            if (personas.Count == 0)
            {
                return BadRequest("No hay Personas Activas o no se han agregado");
            }
            return Ok(personas);
        }
    }
}
