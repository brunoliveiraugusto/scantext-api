using System.Threading.Tasks;

namespace ScanText.Application.Interfaces
{
    public interface IScanAppService
    {
        Task<string> LerTextoImagemAsync(string base64);
    }
}
