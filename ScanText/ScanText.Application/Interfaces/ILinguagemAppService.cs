using ScanText.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILinguagemAppService
    {
        Task InserirLinguagemAsync(LinguagemViewModel linguagemViewModel);
        Task RemoverLinguagemAsync(Guid id);
        Task<IEnumerable<LinguagemViewModel>> ObterTodasLinguagensAsync();
        Task<LinguagemViewModel> ObterLinguagemPorIdAsync(Guid id);
        Task AtualizarLinguagemAsync(LinguagemViewModel linguagemViewModel);
        void ValidarCamposObrigatoriosLinguagem(LinguagemViewModel linguagem);
    }
}
