using AutoMapper;
using ScanText.Application.ViewModels;
using ScanText.Data.Utils;
using ScanText.Domain.Imagem.Entities;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Domain.Usuario.Entities;
using ScanText.Engine.Models;
using ScanText.Engine.Tesseract.Models;
using ScanText.Engine.Utils.Helper;

namespace ScanText.Application.AutoMapper
{
    public class EntitieToViewModel : Profile
    {
        public EntitieToViewModel()
        {
            CreateMap<Imagem, ImagemViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(x => x.Texto))
                .ForMember(dest => dest.Formato, opt => opt.MapFrom(x => x.Formato))
                .ForMember(dest => dest.MeanConfidence, opt => opt.MapFrom(x => x.MeanConfidence))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(x => x.Size))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro))
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(x => x.DataAtualizacao))
                .ForMember(dest => dest.Linguagem, opt => opt.MapFrom(x => x.Linguagem))
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(x => x.IdUsuario))
                .ForMember(dest => dest.UrlImagemBlob, opt => opt.MapFrom(x => x.UrlImagemBlob))
                .ForMember(dest => dest.NomeImagemBlob, opt => opt.MapFrom(x => x.NomeImagemBlob))
                .ForMember(dest => dest.Base64, sc => sc.Ignore());

            CreateMap<Linguagem, LinguagemViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Idioma, opt => opt.MapFrom(x => x.Idioma))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(x => x.Sigla))
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(x => x.DataAtualizacao))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento))
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(x => x.NomeCompleto))
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<QrCode, QrCodeResponseViewModel>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(x => x.Code));

            CreateMap<TesseractImage, ImagemTesseractResponseViewModel>()
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(x => x.Texto))
                .ForMember(dest => dest.MeanConfidence, opt => opt.MapFrom(x => x.MeanConfidence));

            CreateMap<PaginationFilter<Imagem>, PaginationFilterViewModel<ImagemViewModel>>()
                .ForMember(dest => dest.Limit, opt => opt.MapFrom(x => x.Limit))
                .ForMember(dest => dest.Page, opt => opt.MapFrom(x => x.Page))
                .ForMember(dest => dest.Skip, opt => opt.MapFrom(x => x.Skip))
                .ForMember(dest => dest.Take, opt => opt.MapFrom(x => x.Take))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(x => x.Total))
                .ForMember(dest => dest.Pages, opt => opt.MapFrom(x => x.Pages))
                .ForMember(dest => dest.Ascendant, opt => opt.MapFrom(x => x.Ascendant))
                .ForMember(dest => dest.Sort, opt => opt.MapFrom(x => x.Sort));

            CreateMap<ArquivoIdioma, ArquivoIdiomaViewModel>()
                .ForMember(dest => dest.Arquivo, sc => sc.Ignore());
        }
    }
}
