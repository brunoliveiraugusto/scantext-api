using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Domain.Email.Entities.Interfaces
{
    public interface IEmailAddress
    {
        EmailAddress GetEmailAddress(string name, string email, string subject, string plainTextContent, string htmlContent);
    }
}
