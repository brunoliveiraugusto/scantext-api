using ScanText.Domain.BaseDomain;
using ScanText.Domain.Linguagem.Validators;
using System;

namespace ScanText.Domain.Linguagem.Entities
{
    public class ArquivoIdioma : Entity<ArquivoIdioma>
    {
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid IdIdioma { get; set; }
        public Guid IdUsuario { get; set; }
        public string NomeArquivoBlob { get; set; }
        public string UrlArquivoBlob { get; set; }

        public override void Validate()
        {
            Validator.Include(new ArquivoIdiomaValidator());
        }
    }
}
