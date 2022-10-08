using APIHW.Models;
using Microsoft.EntityFrameworkCore;

namespace APIHW.Data
{
    public class PersonaService : EntityBaseRepository<Persona>, IPersonaService
    {
        private readonly DBTareaContext _context;
        public PersonaService(DBTareaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Persona>> AgregarPersona(PersonaDTO pdto)
        {
            var equipo = (from e in _context.Equipos where e.Id == pdto.IdEquipo select e).FirstOrDefault();
            if(equipo == null || !equipo.Active)
            {
                return null;
            }
            var newPersona = new Persona()
            {
                Nombre = pdto.Nombre,
                Apellido = pdto.Apellido,
                Edad = pdto.Edad,
                IdEquipo = pdto.IdEquipo,
                Distrito = pdto.Distrito,
                Active = true,
            };
            await AgregarEntidad(newPersona);
            return await _context.Personas.ToListAsync();
        }
        public async Task<List<Persona>> ActualizarPersona(Persona persona, PersonaDTO personaupdt)
        {
            persona.Nombre = personaupdt.Nombre;
            persona.Apellido = personaupdt.Apellido;
            persona.Edad = personaupdt.Edad;
            persona.Distrito = personaupdt.Distrito;

            return await _context.Personas.ToListAsync();
        }
        public async Task<List<Persona>> BorrarPersona(Persona personadel)
        {
            personadel.Active = false;
            return await _context.Personas.ToListAsync();
        }
        public async Task<List<Persona>> ObtenerPersonasPorEquipo(int id)
        {
            var equipo = await (from e in _context.Equipos where e.Id == id select e).FirstOrDefaultAsync();
            if (equipo == null)
            {
                return null;
            }
            var personas = await (from p in _context.Personas where p.Active && p.IdEquipo == id select p).ToListAsync();
            return personas;
        }
        public async Task<List<Persona>> ObtenerPersonasPorColor(string color)
        {
            var equipo = await (from e in _context.Equipos where e.Color == color select e).FirstOrDefaultAsync();
            if (equipo == null)
            {
                return null;
            }
            var personas = await (from p in _context.Personas where p.Active && p.IdEquipo == equipo.Id select p).ToListAsync();
            return personas;
        }
        public async Task<List<Persona>> ObtenerPersonasPorDistrito(string distrito)
        {
            var dis = await (from p in _context.Personas where p.Distrito == distrito select p).FirstOrDefaultAsync();
            if (dis == null)
            {
                return null;
            }
            var personas = await (from p in _context.Personas where p.Active && p.Distrito == distrito select p).ToListAsync();
            return personas;
        }
        public async Task<List<Persona>> ObtenerPersonasEdadDescendente()
        {
            var personas = await (from p in _context.Personas where p.Active orderby p.Edad descending select p).ToListAsync();
            return personas;
        }
    }
}
