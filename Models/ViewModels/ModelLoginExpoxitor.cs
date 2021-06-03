using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class ModelLoginExpoxitor
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
        public bool Coreect { get; set; }
        public string Mensaje { get; set; }
    }
}
