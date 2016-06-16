using System.Net.Mail;

namespace Framework.AssetLibrary.Mail.Provider
{
    public interface IMailProvider
    {
        void Send(MailSettings settings, MailMessage message);
    }
}