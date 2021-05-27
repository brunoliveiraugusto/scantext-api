using ScanText.Domain.BaseDomain;
using System;

namespace ScanText.Domain.Linguagem.Entities
{
    public class ArquivoIdioma : Entity<ArquivoIdioma>
    {
        public byte[] Arquivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid IdIdioma { get; set; }
        public Guid IdUsuario { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
