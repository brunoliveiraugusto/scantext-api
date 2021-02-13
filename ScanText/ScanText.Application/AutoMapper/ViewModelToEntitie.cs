using AutoMapper;
using ScanText.Application.ViewModels;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Engine.Tesseract.Models;

namespace ScanText.Application.AutoMapper
{
    public class ViewModelToEntitie : Profile
    {
        public ViewModelToEntitie()
        {
            CreateMap<ImagemViewModel, Imagem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Base64, opt => opt.MapFrom(x => x.Base64))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(x => x.Texto))
                .ForMember(dest => dest.Formato, opt => opt.MapFrom(x => x.Formato))
                .ForMember(dest => dest.MeanConfidence, opt => opt.MapFrom(x => x.MeanConfidence))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(x => x.Size))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro))
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(x => x.DataAtualizacao))
                .ForMember(dest => dest.Linguagem, opt => opt.MapFrom(x => x.Linguagem));


            CreateMap<LinguagemViewModel, Linguagem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Idioma, opt => opt.MapFrom(x => x.Idioma))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(x => x.Sigla));

            CreateMap<ImagemViewModel, ImagemOCR>()
                .ForMember(dest => dest.Base64, opt => opt.MapFrom(x => x.Base64))
                .ForMember(dest => dest.SiglaLinguagem, opt => opt.MapFrom(x => x.Linguagem.Sigla))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(x => x.Texto))
                .ForMember(dest => dest.MeanConfidence, opt => opt.MapFrom(x => x.MeanConfidence))
                .ReverseMap();
        }
    }
}
