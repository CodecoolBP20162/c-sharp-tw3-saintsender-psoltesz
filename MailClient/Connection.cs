using MailKit.Net.Imap;
using System.Collections.Generic;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;

namespace MailClient
{
    class Connection
    {
        public string[] Credentials { get; set; }


        public List<Mail> GetMails()
        {
            using (var client = new ImapClient())
            {
                List<Mail> fetchedMails = new List<Mail>();
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(Credentials[0], Credentials[1]);
                // codecool.b1ts.pls@gmail.com, mergeconflict

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

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

        public void SendMail()
        {
            string[] data = MailVisualObjects.SendMailDialog();
            if (data != null)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Credentials[0]));
                message.To.Add(new MailboxAddress(data[0]));
                message.Subject = data[1];

                message.Body = new TextPart("plain")
                {
                    Text = data[2]
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.gmail.com", 587, false);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(Credentials[0], Credentials[1]);

                    client.Send(message);
                    client.Disconnect(true);
                    MessageBox.Show("E-mail sent successfully.");
                }
            }
        }
    }
}
