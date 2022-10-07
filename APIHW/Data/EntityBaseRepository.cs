using APIHW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APIHW.Data
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DBTareaContext _contexto;
        public EntityBaseRepository(DBTareaContext contexto)
        {
            _contexto = contexto;
        }
        public async Task AgregarEntidad(T entity)
        {
            await _contexto.Set<T>().AddAsync(entity);
            await _contexto.SaveChangesAsync();
        }

        public async Task BorrarEntidad(int id)
        {
            var entity = await (from e in _contexto.Set<T>() where e.Id == id select e).FirstOrDefaultAsync();
            EntityEntry entityEntry = _contexto.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodoEntidades() => await (from e in _contexto.Set<T>()
                                                                           select e).ToListAsync();
        public async Task<IEnumerable<T>> ObtenerEntidades() => await (from e in _contexto.Set<T>() 
                                                                       where e.Active
                                                                       select e).ToListAsync();
        public async Task<T> ObtenerEntidad(int id) => await (from e in _contexto.Set<T>() where e.Id == id select e).FirstOrDefaultAsync();

        //public async Task ActualizarEntidad(T entity)
        //{
        //    EntityEntry entityEntry = _contexto.Entry<T>(entity);
        //    entityEntry.State = EntityState.Modified;
        //    await _contexto.SaveChangesAsync();
        //}
    }
}
