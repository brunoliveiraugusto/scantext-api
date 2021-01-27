using ScanText.Infra.Configuration.Database.Context;

namespace ScanText.Domain.Linguagem.Repository
{
    public class LinguagemRepository
    {
        private readonly ScanTextMongoContext _context;

        public LinguagemRepository(ScanTextMongoContext context)
        {
            _context = context;
        }
    }
}
