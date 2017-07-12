using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    class MailListBox
    {
        public ListView mailListView = new ListView();

        public void Setup()
        {
            mailListView.Bounds = new Rectangle(new Point(25, 33), new Size(320, 509));
            mailListView.FullRowSelect = true;
            mailListView.View = View.Details;
            mailListView.AllowColumnReorder = true;

            mailListView.Click += new EventHandler(MailListViewEvent_Click);
        }

        public void FillMailListBox(List<Mail> mailBox)
        {
            mailListView.Columns.Add("Sender");
            mailListView.Columns.Add("Subject");

            string[] row = new string[2];

            foreach (Mail item in mailBox)
            {
                row[0] = item.Sender;
                row[1] = item.Subject;
                ListViewItem listViewItem = new ListViewItem(row);
                mailListView.Items.Add(listViewItem);
            }

            int csw = mailListView.ClientSize.Width;

            for (int i = 1; i < mailListView.Columns.Count; i++)
            {
                mailListView.Columns[i].Width = -1;
                csw -= mailListView.Columns[i].Width;
            }

            mailListView.Columns[1].Width = csw;
        }

        private void MailListViewEvent_Click(object sender, EventArgs e)
        {
            mailListView.SelectedItems[0]  // get selected item
            Mail mail = mailListView.SelectedItems[0].Text // create a new mail object from it
            ShowMailContent(item); // make a get method and pass it to mailcontrol
        }
    }
}
