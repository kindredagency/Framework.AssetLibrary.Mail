using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Framework.AssetLibrary.Mail.Provider;

namespace Framework.AssetLibrary.Mail
{
    public class MailHandler : IMailHandler
    {
        private MailSettings Settings { get; }

        private IMailProvider Provider { get; }

        public MailHandler(MailSettings settings)
        {
            Settings = settings;
            Provider = new DefaultProvider();
        }

        public MailHandler(MailSettings settings, IMailProvider provider)
        {
            Settings = settings;
            Provider = provider;
        }

        public MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, bool html = true)
        {
            return SendEmail(from, to, subject, body, null, null, null, html);
        }

        public MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, Attachment[] attachments, bool html = true)
        {
            return SendEmail(from, to, subject, body, null, null, attachments, html);
        }

        public MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, MailAddress[] cc, Attachment[] attachments, bool html = true)
        {
            return SendEmail(from, to, subject, body, cc, null, attachments, html);
        }

        public MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, MailAddress[] cc, MailAddress[] bcc,  Attachment[] attachments, bool html = true)
        {
            try
            {
                var message = new MailMessage
                {
                    From = from,
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = html,
                    BodyEncoding = Encoding.UTF8,
                    SubjectEncoding = Encoding.UTF8
                };

                foreach (var address in to)
                {
                    message.To.Add(address);
                }

                if (cc != null)
                {
                    foreach (var address in cc)
                    {
                        message.To.Add(address);
                    }
                }

                if (bcc != null)
                {
                    foreach (var address in bcc)
                    {
                        message.To.Add(address);
                    }
                }

                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        message.Attachments.Add(attachment);
                    }
                }

                Provider.Send(Settings, message);

                return new MailStatus { Status = MailStatusType.Sent };
            }
            catch (Exception ex)
            {
                return new MailStatus { Status = MailStatusType.Error, Exception = ex };
            }
        }
    }
}
