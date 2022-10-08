namespace APIHW.Data
{
    public interface IUnitOfWork
    {
        IPersonaService PersonaService { get; }
        IEquipoService EquipoService { get; }
        Task<bool> SaveAsync();
    }
}
