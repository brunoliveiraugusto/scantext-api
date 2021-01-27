using AutoMapper;
using ScanText.Application.ViewModels;
using ScanText.Domain.Linguagem.Entities;

namespace ScanText.Application.AutoMapper
{
    public class ViewModelToEntitie : Profile
    {
        public ViewModelToEntitie()
        {
            CreateMap<LinguagemViewModel, Linguagem>()
                .ForMember(dest => dest.Idioma, opt => opt.MapFrom(x => x.Idioma))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(x => x.Sigla))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
