using System;
using System.Threading.Tasks;
using ScanText.Application.ViewModels;
using ScanText.Domain.Imagem.Entities;

namespace ScanText.Application.Interfaces
{
    public interface IImagemAppService : IServiceApp<ImagemViewModel>
    {
        PaginationFilterViewModel<ImagemViewModel> ObterImagensPaginadasPorUsuario(PaginationFilterViewModel<ImagemViewModel> paginationFilterViewModel);
        Task EnviarEmailImagemProcessada(Guid imagemViewModel);
    }
}
