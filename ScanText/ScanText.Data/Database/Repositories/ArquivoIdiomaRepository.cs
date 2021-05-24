using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Data.Database.Repositories
{
    public class ArquivoIdiomaRepository : Repository<ArquivoIdioma>, IArquivoIdiomaRepository
    {
        public ArquivoIdiomaRepository(ScanTextMongoContext context) : base(context)
        {

        }
    }
}
