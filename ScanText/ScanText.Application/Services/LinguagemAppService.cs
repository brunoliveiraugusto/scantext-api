using AutoMapper;
using ScanText.Application.Interfaces;
using ScanText.Application.ViewModels;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
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

        public async Task InserirLinguagemAsync(LinguagemViewModel linguagemViewModel)
        {
            var linguagem = _mapper.Map<Linguagem>(linguagemViewModel);
            await _linguagemRepository.InserirAsync(linguagem);
        }
    }
}
