using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Framework.AssetLibrary.Mail.Provider
{
    public interface IMailProvider
    {
        void Send(MailSettings settings, MailMessage message);
    }
}
