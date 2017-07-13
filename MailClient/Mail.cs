using System;

namespace MailClient
{
    class Mail
    {
        public int ID { get; set; }
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
