using System;
using ScanText.Domain.BaseDomain;
using ScanText.Domain.Perfil.Validators;

namespace ScanText.Domain.Perfil.Entities
{
    public class Perfil : Entity<Perfil>
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public override void Validate()
        {
            Validator.Include(new PerfilValidator());
        }
    }
}
