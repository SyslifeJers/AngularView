using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class Sala
    {
        public Sala()
        {
            Caja = new HashSet<Caja>();
        }

        public int Id { get; set; }
        public string NumeroSala { get; set; }
        public string Nombre { get; set; }
        public int? TipoSala { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Modificado { get; set; }
        public int? Espacios { get; set; }

        public virtual ICollection<Caja> Caja { get; set; }
    }
}
