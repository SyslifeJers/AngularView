using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models.Context
{
    public partial class ProductoServicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Decripcion { get; set; }
        public decimal? PrecioNormal { get; set; }
        public decimal? PrecioDescuento { get; set; }
        public int? Descuento { get; set; }
        public int? Tipo { get; set; }
        public int? Activo { get; set; }
        public DateTime? Modificado { get; set; }
        public int? Stock { get; set; }
        public int? IdExpositor { get; set; }

        public virtual Expositor IdExpositorNavigation { get; set; }
    }
}
