using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class ExpositorPago
    {
        public int Id { get; set; }
        public int? IdExpositor { get; set; }
        public int? IdTipoPago { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Expositor IdExpositorNavigation { get; set; }
        public virtual MetodoDePago IdTipoPagoNavigation { get; set; }
    }
}
