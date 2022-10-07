using System;
using System.Collections.Generic;

namespace APIHW.ModelosNuevos
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Edad { get; set; } = null!;
        public int IdEquipo { get; set; }
        public string Distrito { get; set; } = null!;
        public bool Active { get; set; }

        public virtual Equipo IdEquipoNavigation { get; set; } = null!;
    }
}
