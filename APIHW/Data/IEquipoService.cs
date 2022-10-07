using APIHW.Models;

namespace APIHW.Data
{
    public interface IEquipoService : IEntityBaseRepository<Equipo>
    {
        Task<List<Equipo>> AgregarEquipo(EquipoDTO equi);
        Task<List<Equipo>> ActualizarEquipo(Equipo equi, EquipoDTO equiupdt);
        Task<List<Equipo>> BorrarEquipo(Equipo equi);
    }
}
