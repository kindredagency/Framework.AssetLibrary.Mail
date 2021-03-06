﻿using System.Net.Mail;

namespace Framework.AssetLibrary.Mail
{
    public class MailSettings
    {
        public MailSettings(string username, string password, string host, int port)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = port;
            EnableSsl = false;
            Timeout = 10000;
            DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public bool EnableSsl { get; set; }

        public SmtpDeliveryMethod DeliveryMethod { get; set; }

        public int Timeout { get; set; }
    }
}