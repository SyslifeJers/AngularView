using AngularView.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class ModelListadoVentas
    {
        public List<VentaEspacio> ventaEspacios { get; set; }
        public List<Vendedores> Vendedores { get; set; }
    }
}
