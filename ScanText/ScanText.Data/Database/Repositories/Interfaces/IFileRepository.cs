using System.Threading.Tasks;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task<string> Upload(string fileName, byte[] file);
        Task<bool> Delete(string fileName);
    }
}
