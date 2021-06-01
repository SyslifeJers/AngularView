using AngularView.Models;
using AngularView.Models.Context;
using AngularView.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularView
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginFreeModel, Vendedores>();
            CreateMap<Vendedores, LoginFreeModel>();

            CreateMap<ProcesoVentaModel, Expositor>();
            CreateMap<Expositor, ProcesoVentaModel>();

            // CreateMap<Enfermera, ModelEnfermera>().ForMember(dest => dest.Latitud, opt => opt.MapFrom(src => src.UltLat)).ForMember(dest => dest.Longitud, opt => opt.MapFrom(src => src.UltLon));


        }
    }
}
