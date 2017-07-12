using System;

using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Collections.Generic;

namespace MailClient
{
    class MailServerConnection
    {
        public static List<Mail> Connect()
        {
            using (var client = new ImapClient())
            {
                List<Mail> mailBox = new List<Mail>();
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("codecool.b1ts.pls@gmail.com", "mergeconflict");

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);

                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    Mail mail = new Mail(message.From.ToString(), message.Subject, message.Body.ToString(), message.Date.LocalDateTime);
                    mailBox.Add(mail);
                }

                client.Disconnect(true);
                return mailBox;
            }
        }
    }
}
