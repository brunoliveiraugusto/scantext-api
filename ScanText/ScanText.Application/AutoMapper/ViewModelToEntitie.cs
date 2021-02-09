using AutoMapper;
using ScanText.Application.ViewModels;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Engine.Tesseract.Entities;

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
                .ForMember(dest => dest.Linguagem, opt => opt.MapFrom(x => x.Linguagem));


            CreateMap<LinguagemViewModel, Linguagem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Idioma, opt => opt.MapFrom(x => x.Idioma))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(x => x.Sigla));

            CreateMap<ImagemViewModel, ImagemOCR>()
                .ForMember(dest => dest.Base64, opt => opt.MapFrom(x => x.Base64))
                .ForMember(dest => dest.SiglaLinguagem, opt => opt.MapFrom(x => x.Linguagem.Sigla))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(x => x.Texto))
                .ReverseMap();
        }
    }
}
