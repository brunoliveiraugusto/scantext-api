namespace ScanText.Domain.Shared.Validators.Messages
{
    public static class ValidationMessages
    {
        public static string CampoObrigatorio(string name) 
        { 
            return $"O preenchimento do campo {name} é obrigatório.";
        }
    }
}
