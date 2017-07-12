using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    class MailControl
    {
        public List<Mail> mailBox = new List<Mail>();
        public MailListBox mailListBox = new MailListBox();
        public MailContentBox contentBox = new MailContentBox();

        public void ListMails()
        {
            mailListBox.FillMailListBox(mailBox);
            mailListBox.mailListView.Refresh();
        }

        public void DisplayMailContent()
        {
            contentBox.contentBox.Text = mailListBox.
        }
    }
}
