using ScanText.Domain.Perfil;
using ScanText.Infra.Configuration.Database.Context;

namespace ScanText.Data.Database.Repositories
{
    class PerfilRepository : Repository<Perfil>
    {
        public PerfilRepository(ScanTextMongoContext context) : base(context)
        {
        }


    }
}
