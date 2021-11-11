using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Subtotal { get; set; }
        public int IdOrden { get; set; }
        public int Cant { get; set; }

        public virtual Venta IdOrdenNavigation { get; set; }
    }
}
