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
        public List<ModelSelect> listProductSelected { get; set; }
        public DetalleCaja detalleCaja { get; set; }
        public int IdExpositor { get; set; }
        
    }
    public class ModelSelect
    {
        public int IdProduct { get; set; }
        public int Cant { get; set; }
        public bool Selected { get; set; }
        public string Producto { get; set; }
    }
}
