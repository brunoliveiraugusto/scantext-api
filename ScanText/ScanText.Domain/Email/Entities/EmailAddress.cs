namespace ScanText.Domain.Email.Entities
{
    public class EmailAddress
    {
        public EmailAddress()
        {

        }

        public EmailAddress(string name, string email, string subject, string plainTextContent, string htmlContent)
        {
            Name = name;
            Email = email;
            Subject = subject;
            PlainTextContent = plainTextContent;
            HtmlContent = htmlContent;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}
