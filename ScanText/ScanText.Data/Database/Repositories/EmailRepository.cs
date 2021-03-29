using Microsoft.Extensions.Options;
using ScanText.Data.Database.Repositories.Interfaces;
using ScanText.Data.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmailAddressDomain = ScanText.Domain.Email.Entities;

namespace ScanText.Data.Database.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly SendGridSettings _sendGrid;

        public EmailRepository(IOptions<SendGridSettings> sendGridOptions)
        {
            _sendGrid = sendGridOptions.Value;
        }

        public async Task<bool> EnviarEmailAsync(EmailAddressDomain.EmailAddress email)
        {
            try
            {
                var client = new SendGridClient(_sendGrid.Key);
                var from = new EmailAddress(_sendGrid.To, _sendGrid.Name);
                var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(email.Email, email.Name), email.Subject, email.PlainTextContent, email.HtmlContent);
                var response = await client.SendEmailAsync(msg);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //Gravar Log
                return false;
            }
        }
    }
}
