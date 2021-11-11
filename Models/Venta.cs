using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Rzcliente { get; set; }
        public int IdCliente { get; set; }
        public int IdExpositor { get; set; }
        public string Rfccliente { get; set; }
        public string DireccionClient { get; set; }
        public string Telefono { get; set; }
        public string Total { get; set; }
        public string TipoEnvio { get; set; }
        public string TipoPago { get; set; }
        public string Observaciones { get; set; }
        public int Activo { get; set; }
        public string ExpoRz { get; set; }
        public string ExpoRfc { get; set; }
        public string ExpoDireccion { get; set; }
        public string ExpoCelular { get; set; }
        public string ExpoCorreo { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual Expositor IdExpositorNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
