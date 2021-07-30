using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class DetalleCaja
    {
        public int Id { get; set; }
        public int IdExpositor { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string RedWhats { get; set; }
        public string RedFacebook { get; set; }
        public string RedInstagram { get; set; }
        public string VideoYoutube { get; set; }
        public int IdCaja { get; set; }
        public DateTime? Modificado { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }

        public virtual Caja IdCajaNavigation { get; set; }
        public virtual Expositor IdExpositorNavigation { get; set; }
    }
}
