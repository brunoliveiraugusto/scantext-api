﻿using AutoMapper;
using ScanText.Application.ViewModels;
using ScanText.Domain.UsuarioDTO.Entities;

namespace ScanText.Application.AutoMapper
{
    public class EntitieToViewModel : Profile
    {
        public EntitieToViewModel()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento))
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(x => x.NomeCompleto))
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}