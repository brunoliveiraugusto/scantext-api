using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Infra.Configuration.Database.Context;
using System;
using System.Collections.Generic;

namespace ScanText.Data.Database.Repositories
{
    public class LinguagemRepository : Repository<Linguagem>, ILinguagemRepository
    {
        public LinguagemRepository(ScanTextMongoContext context) : base(context)
        {

        }
    }
}
