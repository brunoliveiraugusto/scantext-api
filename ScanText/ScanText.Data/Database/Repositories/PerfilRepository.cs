using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Perfil;
using ScanText.Infra.Configuration.Database.Context;

namespace ScanText.Data.Database.Repositories
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(ScanTextMongoContext context) : base(context)
        {
        }


    }
}
