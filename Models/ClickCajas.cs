using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class ClickCajas
    {
        public int Id { get; set; }
        public int IdCaja { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Caja IdCajaNavigation { get; set; }
        public virtual Clientes IdClienteNavigation { get; set; }
    }
}
