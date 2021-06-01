using AngularView.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class RegistroCajonVendedor
    {
        public Caja GetCaja { get; set; }
        public int id_Cajon { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Negocio { get; set; }

    }
}
