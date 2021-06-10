using AngularView.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite.Geometries;
using System;

namespace AngularView.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<IdentityUser, UsuarioDTO>();
        }

    }
}
