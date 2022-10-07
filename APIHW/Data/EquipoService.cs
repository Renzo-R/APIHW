using APIHW.Models;

namespace APIHW.Data
{
    public class EquipoService : EntityBaseRepository<Equipo>, IEquipoService
    {
        private readonly DBTareaContext _context;
        public EquipoService(DBTareaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Equipo>> ActualizarEquipo(Equipo equi, EquipoDTO equiupdt)
        {
            equi.Nombre = equiupdt.Nombre;
            equi.Descripcion = equiupdt.Descripcion;
            equi.Color = equiupdt.Color;

            await _context.SaveChangesAsync();
            return await _context.Equipos.ToListAsync();
        }

        public async Task<List<Equipo>> AgregarEquipo(EquipoDTO equi)
        {
            var newequipo = new Equipo()
            {
                Nombre = equi.Nombre,
                Descripcion = equi.Descripcion,
                Color = equi.Color,
                Active = true,
            };
            await AgregarEntidad(newequipo);
            return await _context.Equipos.ToListAsync();
        }

        public async Task<List<Equipo>> BorrarEquipo(Equipo equidel)
        {
            equidel.Active = false;
            foreach (Persona p in equidel.Personas)
            {
                if (p != null)
                {
                    p.Active = false;
                }
            }
            await _context.SaveChangesAsync();
            return await _context.Equipos.ToListAsync();
        }
    }
}
