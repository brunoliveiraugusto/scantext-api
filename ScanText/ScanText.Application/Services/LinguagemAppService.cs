using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class LinguagemAppService : ILinguagemAppService
    {
        private readonly ILinguagemRepository _linguagemRepository;
        private readonly IMapper _mapper;

        public LinguagemAppService(ILinguagemRepository linguagemRepository, IMapper mapper)
        {
            _linguagemRepository = linguagemRepository;
            _mapper = mapper;
        }

        public async Task AtualizarAsync(LinguagemViewModel linguagemViewModel)
        {
            ValidarCamposObrigatoriosLinguagem(linguagemViewModel);
            var linguagem = _mapper.Map<Linguagem>(linguagemViewModel);
            await _linguagemRepository.AtualizarAsync(linguagem);
        }

        public async Task InserirAsync(LinguagemViewModel linguagemViewModel)
        {
            ValidarCamposObrigatoriosLinguagem(linguagemViewModel);
            var linguagem = _mapper.Map<Linguagem>(linguagemViewModel);
            await _linguagemRepository.InserirAsync(linguagem);
        }

        public async Task<LinguagemViewModel> ObterPorIdAsync(Guid id)
        {
            var linguagem = await _linguagemRepository.ObterPorIdAsync(id);
            return _mapper.Map<LinguagemViewModel>(linguagem);
        }

        public async Task<IEnumerable<LinguagemViewModel>> ObterTodosAsync()
        {
            var linguagens = await _linguagemRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<LinguagemViewModel>>(linguagens);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _linguagemRepository.RemoverAsync(id);
        }

        public void ValidarCamposObrigatoriosLinguagem(LinguagemViewModel linguagem)
        {
            if(string.IsNullOrEmpty(linguagem.Idioma))
            {
                throw new Exception("Informe o Idioma.");
            }

            if (string.IsNullOrEmpty(linguagem.Sigla))
            {
                throw new Exception("Informe a Sigla.");
            }
        }
    }
}
