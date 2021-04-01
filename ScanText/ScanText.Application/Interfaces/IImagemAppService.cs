using System;
using ScanText.Application.ViewModels;
using ScanText.Domain.Linguagem.Entities;

namespace ScanText.Application.Interfaces
{
    public interface IImagemAppService : IServiceApp<ImagemViewModel>
    {
        Imagem ImagemViewModelToImagem(ImagemViewModel imagemViewModel);
        PaginationFilterViewModel<ImagemViewModel> ObterImagensPaginadasPorUsuario(PaginationFilterViewModel<ImagemViewModel> paginationFilterViewModel);
    }
}
