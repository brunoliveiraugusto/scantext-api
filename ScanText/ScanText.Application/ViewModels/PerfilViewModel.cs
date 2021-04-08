using System;

namespace ScanText.Application.ViewModels
{
    public class PerfilViewModel
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
