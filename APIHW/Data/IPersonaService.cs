using APIHW.Models;

namespace APIHW.Data
{
    public interface IPersonaService : IEntityBaseRepository<Persona>
    {
        Task<List<Persona>> AgregarPersona(PersonaDTO p);
        Task<List<Persona>> ActualizarPersona(Persona p, PersonaDTO pUpdt);
        Task<List<Persona>> BorrarPersona(Persona p);
        Task<List<Persona>> ObtenerPersonasPorEquipo(int id);
        Task<List<Persona>> ObtenerPersonasPorColor(string color);
        Task<List<Persona>> ObtenerPersonasPorDistrito(string distrito);
        Task<List<Persona>> ObtenerPersonasEdadDescendente();
    }
}
