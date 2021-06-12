using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class ClickProdcuto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual ProductoServicio IdProductoNavigation { get; set; }
    }
}
