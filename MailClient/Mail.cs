using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    class Mail
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Mail(string sender, string subject, string content, DateTime date)
        {
            Sender = sender;
            Subject = subject;
            Content = content;
            Date = date;
        }
    }
}
