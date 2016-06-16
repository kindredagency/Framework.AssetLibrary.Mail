using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Framework.AssetLibrary.Mail
{
    public interface IMailHandler
    {
        MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, bool html = true);

        MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, Attachment[] attachments, bool html = true);

        MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, MailAddress[] cc, Attachment[] attachments, bool html = true);

        MailStatus SendEmail(MailAddress from, MailAddress[] to, string subject, string body, MailAddress[] cc, MailAddress[] bcc, Attachment[] attachments, bool html = true);
    }
}
