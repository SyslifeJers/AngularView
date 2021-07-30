using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class TipoEnvio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdExpo { get; set; }
    }
}
