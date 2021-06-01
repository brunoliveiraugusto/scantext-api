using Microsoft.AspNetCore.Http;
using System;

namespace ScanText.Application.ViewModels
{
    public class ArquivoIdiomaViewModel
    {
        public Guid Id { get; set; }
        public string Arquivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid IdIdioma { get; set; }
        public Guid IdUsuario { get; set; }
        public string NomeArquivoBlob { get; set; }
        public string UrlArquivoBlob { get; set; }
    }
}
