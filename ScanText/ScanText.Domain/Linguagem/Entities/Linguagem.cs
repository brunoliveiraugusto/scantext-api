using ScanText.Domain.EntityDomain;
using ScanText.Domain.Linguagem.Validators;
using System;

namespace ScanText.Domain.Linguagem.Entities
{
    public class Linguagem : Entity<Linguagem>
    {
        public string Sigla { get; set; }
        public string Idioma { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public override void Validate()
        {
            Validator.Include(new LinguagemValidator());
        }
    }
}
