using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class ProcesoVentaModel
    {
        public int Id_Cajon { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Correo { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "{0} Tamaño {2} y {1}.", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "{0} Tamaño {2} y {1}.", MinimumLength = 4)]
        public string Apellidos { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Celular { get; set; }
        [StringLength(18, ErrorMessage = "{0} Tamaño {2} y {1}.", MinimumLength = 3)]
        public string Negocio { get; set; }
        public string Costo { get; set; }
        public string NombreCajon { get; set; }
        public string Respuesta { get; set; }

    }
}
