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
        public List<TipoPago> listTipoPago { get; set; }     
        public List<TipoEnvio> listTipoEnvio { get; set; }
        public DetalleCaja detalleCaja { get; set; }
        public int IdExpositor { get; set; }
        public int TipoPago { get; set; }
        public int TipoEnvio { get; set; }
        public string razonSocial { get; set; }
        public string observaciones { get; set; }
        public string RFC { get; set; }
        public  string Direccion  { get; set; }
        public string  Telefono { get; set; }
        public  string Email { get; set; }
        public string listpro { get; set; }
        public Expositor GetExpositor { get; set; }
        public Clientes GetClientes { get; set; }
        public double Total { get; set; }
        public double Iva { get; set; }
    }
    public class ModelSelect
    {
        public int IdProduct { get; set; }
        public int Cant { get; set; }
        public bool Selected { get; set; }
        public string Producto { get; set; }
    }
    public class ModelEnvioFinal
    {
        public List<ModelSelect> listProductSelected { get; set; }
        public string listTipoPago { get; set; }
        public string listTipoEnvio { get; set; }
        public int idCajon { get; set; }
        public int TipoPago { get; set; }
        public int TipoEnvio { get; set; }
        public string razonSocial { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int idExpositor { get; set; }
        public int idCliente { get; set; }
        public double Total { get; set; }
        public double Iva { get; set; }
    }
}
