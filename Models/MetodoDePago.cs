using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AngularView.Models
{
    public partial class MetodoDePago
    {
        public MetodoDePago()
        {
            ExpositorPago = new HashSet<ExpositorPago>();
        }

        public int Id { get; set; }
        public string TpoDePago { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Modifacdo { get; set; }

        public virtual ICollection<ExpositorPago> ExpositorPago { get; set; }
    }
}
