using System;

namespace ScanText.Application.ViewModels
{
    public class LinguagemViewModel
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Idioma { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
