using ScanText.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILinguagemAppService : IServiceApp<LinguagemViewModel>
    {
        void ValidarCamposObrigatoriosLinguagem(LinguagemViewModel linguagem);
    }
}
