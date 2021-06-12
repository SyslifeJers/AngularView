using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class ModelDetalleCajon
    {
        public bool SiDAtos { get; set; }
        public List<ProductoServicio> listProductoServicios { get; set; }
        public DetalleCaja detalleCaja { get; set; }
    }
}
