using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class ModelCorreo
    {
        public string Tipo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required]
        public string Mensaje { get; set; }
    }
}
