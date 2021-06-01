using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models.Context
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
        public int? Activo { get; set; }
        public DateTime? Modificado { get; set; }
        public int? Espacios { get; set; }
        public int? IdEvento { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual ICollection<Caja> Caja { get; set; }
    }
}
