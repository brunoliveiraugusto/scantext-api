namespace ScanText.Domain.Utils.Notification
{
    public struct NotificationItem
    {
        public string Chave { get; private set; }
        public string Valor { get; private set; }

        public NotificationItem(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }
    }
}
