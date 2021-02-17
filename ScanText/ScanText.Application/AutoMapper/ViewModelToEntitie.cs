using AutoMapper;
using ScanText.Application.ViewModels;
using ScanText.Data.Utils;
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
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(x => x.Sigla))
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(x => x.DataAtualizacao))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            CreateMap<ImagemViewModel, ImagemOCR>()
                .ForMember(dest => dest.Base64, opt => opt.MapFrom(x => x.Base64))
                .ForMember(dest => dest.SiglaLinguagem, opt => opt.MapFrom(x => x.Linguagem.Sigla))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(x => x.Texto))
                .ForMember(dest => dest.MeanConfidence, opt => opt.MapFrom(x => x.MeanConfidence))
                .ReverseMap();

            CreateMap<PaginationFilterViewModel<ImagemViewModel>, PaginationFilter<Imagem>>()
                .ForMember(dest => dest.Limit, opt => opt.MapFrom(x => x.Limit))
                .ForMember(dest => dest.Page, opt => opt.MapFrom(x => x.Page))
                .ForMember(dest => dest.Skip, opt => opt.MapFrom(x => x.Skip))
                .ForMember(dest => dest.Take, opt => opt.MapFrom(x => x.Take))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(x => x.Total))
                .ForMember(dest => dest.Pages, opt => opt.MapFrom(x => x.Pages))
                .ForMember(dest => dest.Ascendant, opt => opt.MapFrom(x => x.Ascendant))
                .ForMember(dest => dest.Sort, opt => opt.MapFrom(x => x.Sort))
                .ReverseMap();
        }
    }
}
