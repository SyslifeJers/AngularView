using AngularView.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class ModelArchivo
    {
        public int id_Producto { get; set; }
        public IFormFile File { get; set; }
        public ProductoServicio productoServicio {get;set;}
        public string mensaje { get; set; }

        public ModelArchivo ()
        {
            mensaje = "";
        }
    }
}
