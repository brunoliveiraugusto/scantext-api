using ScanText.Domain.DomainObjects;

namespace ScanText.Domain.Linguagem.Entities
{
    public class Imagem : Entity<Imagem>
    {
        public string Nome { get; set; }
        public long Size { get; set; }
        public string Formato { get; set; }
        public string Base64 { get; set; }
        public string Texto { get; set; }
        public Linguagem Linguagem { get; set; }
    }
}
