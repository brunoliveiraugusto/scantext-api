using ScanText.Domain.DomainObjects;
using System;

namespace ScanText.Domain.Linguagem.Entities
{
    public class Linguagem : Entity<Linguagem>
    {
        public string Sigla { get; set; }
        public string Idioma { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
