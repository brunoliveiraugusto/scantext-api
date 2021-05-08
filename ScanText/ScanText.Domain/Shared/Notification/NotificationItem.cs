namespace ScanText.Domain.Shared.Notification
{
    public class NotificationItem
    {
        public string Chave { get; private set; }
        public string Valor { get; private set; }

        public NotificationItem(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }

        public NotificationItem GetNotificationItem()
        {
            return this;
        }
    }
}
