using ScanText.Domain.BaseDomain;
using System;
using User = ScanText.Domain.Usuario.Entities;

namespace ScanText.Domain.Linguagem.Entities
{
    public class ArquivoIdioma : Entity<ArquivoIdioma>
    {
        public byte[] Arquivo { get; set; }
        public string SiglaIdioma { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public User.Usuario Usuario { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
