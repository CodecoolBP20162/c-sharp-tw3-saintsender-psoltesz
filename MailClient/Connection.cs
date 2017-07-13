using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using MailKit;

namespace MailClient
{
    class Connection
    {
        public List<Mail> GetMails(string user, string password)
        {
            using (var client = new ImapClient())
            {
                List<Mail> fetchedMails = new List<Mail>();
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(user, password);
                // "codecool.b1ts.pls@gmail.com", "mergeconflict"

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);

                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    Mail mail = new Mail(message.From.ToString(), message.Subject, message.TextBody, message.Date.LocalDateTime);
                    fetchedMails.Add(mail);
                }
                client.Disconnect(true);
                return fetchedMails;
            }
        }
    }
}
