using System;
using ScanText.Domain.DomainObjects;

namespace ScanText.Domain.Perfil
{
    public class Perfil : Entity<Perfil>
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
