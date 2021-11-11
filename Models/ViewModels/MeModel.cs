using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class MeModel
    {
        public Clientes clientes { get; set; }
        public List<Venta> ventas { get; set; }
    }
}
