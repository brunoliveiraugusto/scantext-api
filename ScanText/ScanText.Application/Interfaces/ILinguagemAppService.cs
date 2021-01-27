using ScanText.Domain.Linguagem.Entities;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILinguagemAppService
    {
        Task InserirLinguagemAsync(Linguagem linguagem);
    }
}
