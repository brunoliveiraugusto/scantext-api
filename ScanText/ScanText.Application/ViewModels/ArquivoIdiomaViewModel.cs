using System;

namespace ScanText.Application.ViewModels
{
    public class ArquivoIdiomaViewModel
    {
        public byte[] Arquivo { get; set; }
        public string SiglaIdioma { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
