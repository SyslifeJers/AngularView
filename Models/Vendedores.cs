using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class Vendedores
    {
        public Vendedores()
        {
            AltaExpositor = new HashSet<AltaExpositor>();
            PagosComision = new HashSet<PagosComision>();
            VentaEspacio = new HashSet<VentaEspacio>();
        }

        public int Id { get; set; }
        public string IdFreelance { get; set; }
        public string Nombre { get; set; }
        public string Token { get; set; }
        public string Correo { get; set; }
        public string Passworsd { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Modificado { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public decimal? Comision { get; set; }

        public virtual ICollection<AltaExpositor> AltaExpositor { get; set; }
        public virtual ICollection<PagosComision> PagosComision { get; set; }
        public virtual ICollection<VentaEspacio> VentaEspacio { get; set; }
    }
}
