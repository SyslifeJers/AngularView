using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models.Context
{
    public partial class PagosComision
    {
        public int Id { get; set; }
        public decimal? Pago { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Activo { get; set; }
        public int? IdVendedor { get; set; }

        public virtual Vendedores IdVendedorNavigation { get; set; }
    }
}
