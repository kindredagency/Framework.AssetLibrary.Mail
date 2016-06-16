using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Framework.AssetLibrary.Mail.Provider
{
    public class DefaultProvider : IMailProvider
    {
        public void Send(MailSettings settings, MailMessage message)
        {
            var smtpClient = new SmtpClient
            {
                Host = settings.Host,
                Port = settings.Port,
                EnableSsl = settings.EnableSsl,
                Timeout = settings.Timeout,
                DeliveryMethod = settings.DeliveryMethod,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(settings.Username, settings.Password),
            };

            smtpClient.Send(message);
        }
    }
}
