using APIHW.Models;

namespace APIHW.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DBTareaContext _context;

        public UnitOfWork(DBTareaContext context)
        {
            _context = context;
        }

         public IPersonaService PersonaService => new PersonaService(_context);

        public IEquipoService EquipoService => new EquipoService(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
