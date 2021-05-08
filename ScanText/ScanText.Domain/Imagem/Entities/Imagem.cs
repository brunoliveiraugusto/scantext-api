using ScanText.Domain.BaseDomain;
using Entitie = ScanText.Domain.Linguagem.Entities;
using System;
using ScanText.Domain.Imagem.Validators;

namespace ScanText.Domain.Imagem.Entities
{
    public class Imagem : Entity<Imagem>
    {
        public string Nome { get; set; }
        public long Size { get; set; }
        public string Formato { get; set; }
        public string Base64 { get; set; }
        public string Texto { get; set; }
        public float MeanConfidence { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Entitie.Linguagem Linguagem { get; set; }
        public Guid IdUsuario { get; set; }

        public override void Validate()
        {
            Validator.Include(new ImagemValidator());
        }
    }
}
