using ScanText.Application.ViewModels;
using ScanText.Domain.Linguagem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILinguagemAppService : IServiceApp<LinguagemViewModel>
    {
        Linguagem LinguagemViewModelToLinguagem(LinguagemViewModel linguagemViewModel);
    }
}
