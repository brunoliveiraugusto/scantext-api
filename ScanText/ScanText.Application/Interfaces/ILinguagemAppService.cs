using ScanText.Application.ViewModels;
using ScanText.Domain.Imagem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILinguagemAppService : IServiceApp<LinguagemViewModel>
    {
        void ValidarCamposObrigatoriosLinguagem(LinguagemViewModel linguagemViewModel);
        Linguagem LinguagemViewModelToLinguagem(LinguagemViewModel linguagemViewModel);
    }
}
