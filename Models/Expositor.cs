using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class Expositor
    {
        public Expositor()
        {
            AltaExpositor = new HashSet<AltaExpositor>();
            DetalleCaja = new HashSet<DetalleCaja>();
            ExpositorPago = new HashSet<ExpositorPago>();
            ProductoServicio = new HashSet<ProductoServicio>();
            TipoEnvio = new HashSet<TipoEnvio>();
            TipoPago = new HashSet<TipoPago>();
            VentaEspacio = new HashSet<VentaEspacio>();
        }

        public int Id { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? Registro { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int? Activo { get; set; }
        public DateTime? Modificado { get; set; }
        public string Celular { get; set; }
        public string Negocio { get; set; }

        public virtual ICollection<AltaExpositor> AltaExpositor { get; set; }
        public virtual ICollection<DetalleCaja> DetalleCaja { get; set; }
        public virtual ICollection<ExpositorPago> ExpositorPago { get; set; }
        public virtual ICollection<ProductoServicio> ProductoServicio { get; set; }
        public virtual ICollection<TipoEnvio> TipoEnvio { get; set; }
        public virtual ICollection<TipoPago> TipoPago { get; set; }
        public virtual ICollection<VentaEspacio> VentaEspacio { get; set; }
    }
}
