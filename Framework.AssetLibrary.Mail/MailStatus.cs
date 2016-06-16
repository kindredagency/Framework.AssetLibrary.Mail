using System;

namespace Framework.AssetLibrary.Mail
{
    public class MailStatus
    {
        public MailStatusType Status { get; internal set; }

        public Exception Exception { get; internal set; }
      
    }
}