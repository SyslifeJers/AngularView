using AngularView.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView.Models.ViewModels
{
    public class AltaExpoFreelance
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Negocio { get; set; }
        public bool Registrado { get; set; }
        public Expositor vendedores { get; set; }
        public int idevento { get; set; }
        public int idSalas { get; set; }
        public int idCajas { get; set; }
        public List<Sala> GetSalas { get; set; }
        public List<Caja> GetCajas { get; set; }
        public List<Evento> GetEventos { get; set; }


    }
}
