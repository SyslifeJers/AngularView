using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            ClickCajas = new HashSet<ClickCajas>();
            ClickProdcuto = new HashSet<ClickProdcuto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? Fecha { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public DateTime UtlConexion { get; set; }
        public string Token { get; set; }

        public virtual ICollection<ClickCajas> ClickCajas { get; set; }
        public virtual ICollection<ClickProdcuto> ClickProdcuto { get; set; }
    }
}
