using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace MailClient
{
    class MailData
    {
        private List<Mail> mailBox = new List<Mail>();
        private int idCounter = 0;
        public Connection connection = new Connection();


        public void AddMail(string sender, string subject, string content, DateTime date)
        {
            Mail mail = new Mail(sender, subject, content, date);
            mail.ID = idCounter++;
            mailBox.Add(mail);
        }

        public List<Mail> GetMailBox()
        {
            return mailBox;
        }

        public Mail GetItemOnClick(ListViewItem selected)
        {
            int ID = Convert.ToInt32(selected.Name);
            Mail mail = mailBox.Find(
                delegate (Mail m)
                {
                    return m.ID == ID;
                });
            return mail;
        }

        public void StartMailBoxRefreshThread()
        {
            Thread t = new Thread(new ThreadStart(RefreshMailBox));
            t.Start();
        }

        public void RefreshMailBox()
        {
            lock (this)
            {
                idCounter = 0;
                try
                {
                    List<Mail> temp = connection.GetMails();
                    foreach (Mail item in temp)
                    {
                        item.ID = idCounter++;
                    }
                    mailBox = temp;
                }
                catch
                {
                    MessageBox.Show("Invalid credentials. Please try again.");
                    string[] credentials = MailVisualObjects.LoginDialog();
                    connection.Credentials = credentials;
                }
            }
        }
    }
}
