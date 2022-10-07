using APIHW.Data;
using System;
using System.Collections.Generic;

namespace APIHW.Models
{
    public partial class Equipo : IEntityBase
    {
        public Equipo()
        {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Color { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
