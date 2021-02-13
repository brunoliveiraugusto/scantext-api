using System;

namespace ScanText.Application.ViewModels
{
    public class ImagemViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public long Size { get; set; }
        public string Formato { get; set; }
        public string Base64 { get; set; }
        public string Texto { get; set; }
        public LinguagemViewModel Linguagem { get; set; }
    }
}
