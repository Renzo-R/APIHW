using APIHW.Data;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIHW.Models
{
    public partial class Persona : IEntityBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public int IdEquipo { get; set; }
        public string Distrito { get; set; } = null!;
        public bool Active { get; set; }
        [JsonIgnore]
        public virtual Equipo IdEquipoNavigation { get; set; } = null!;
    }
}
