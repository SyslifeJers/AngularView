using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class LoginFreeModel
    {
     
        [Required]
        public string Nombre { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Correo { get; set; }
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "{0} Tamaño {2} y {1}.", MinimumLength = 8)]
        [Required]
        public string Passworsd { get; set; }
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "{0} Tamaño {2} y {1}.", MinimumLength = 8)]
        [Required]
        [Compare(nameof(Passworsd), ErrorMessage = "La confirmación debe ser igual a la contraseña")]
        public string ConfirmPassworsd { get; set; }
        public string Respuestas { get; set; }


    }
}
