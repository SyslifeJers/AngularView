using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models.Context
{
    public partial class Caja
    {
        public Caja()
        {
            VentaEspacio = new HashSet<VentaEspacio>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? IdSala { get; set; }
        public int? IdEvento { get; set; }
        public int? Tipo { get; set; }
        public int? Activo { get; set; }
        public DateTime? Modificado { get; set; }
        public string Costo { get; set; }
        public int? Ocupado { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<VentaEspacio> VentaEspacio { get; set; }
    }
}
