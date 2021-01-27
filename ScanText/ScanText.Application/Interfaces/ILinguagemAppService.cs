using ScanText.Application.ViewModels;
using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface ILinguagemAppService
    {
        Task InserirLinguagemAsync(LinguagemViewModel linguagem);
    }
}
