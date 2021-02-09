using ScanText.Domain.DomainObjects;
using System;

namespace ScanText.Domain.Linguagem.Entities
{
    public class Linguagem : Entity<Linguagem>
    {
        public string Sigla { get; set; }
        public string Idioma { get; set; }
    }
}
