using System.Threading.Tasks;
using ScanText.Domain.Email.Entities;

namespace ScanText.Data.Database.Repositories.Interfaces
{
    public interface IEmailRepository
    {
        Task<bool> EnviarEmailAsync(EmailAddress email);
    }
}
