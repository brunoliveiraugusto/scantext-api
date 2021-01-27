using ScanText.Application.Interfaces;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using System.Threading.Tasks;

namespace ScanText.Application.Services
{
    public class LinguagemAppService : ILinguagemAppService
    {
        private readonly ILinguagemRepository _linguagemRepository;

        public LinguagemAppService(ILinguagemRepository linguagemRepository)
        {
            _linguagemRepository = linguagemRepository;
        }

        public async Task InserirLinguagemAsync(Linguagem linguagem)
        {
            await _linguagemRepository.InserirAsync(linguagem);
        }
    }
}
