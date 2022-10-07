namespace APIHW.Data
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> ObtenerTodoEntidades();
        Task<IEnumerable<T>> ObtenerEntidades();
        Task<T> ObtenerEntidad(int id);
        Task AgregarEntidad(T entity);
        Task BorrarEntidad(int id);
    }
}
