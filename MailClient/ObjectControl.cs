using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MailClient
{
    class ObjectControl
    {
        public MailData mailController = new MailData();
        public MailVisualObjects objects = new MailVisualObjects();
        private ListViewItem selectedItem = new ListViewItem();


        public void ListMails()
        {
            mailController.StartMailBoxRefreshThread();
            objects.mailListView.Items.Clear();
            FillMailListBox(mailController.GetMailBox());
            SetSelectedItem();
        }

        public string[] GetCredentials()
        {
            return mailController.connection.Credentials;
        }

        public void SetCredentials(string[] credentials)
        {
            mailController.connection.Credentials = credentials;
        }

        private void DisplayMailContent()
        {
            objects.contentBox.Text = mailController.GetItemOnClick(selectedItem).Content;
        }

        private void SetSelectedItem()
        {
            try
            {
                objects.mailListView.Items.Find(selectedItem.Name, false)[0].Selected = true;
            }
            catch { }
        }

        public void FillMailListBox(List<Mail> mailBox)
        {
            string[] row = new string[3];

            foreach (Mail item in mailBox)
            {
                row[0] = item.Sender;
                row[1] = item.Subject;
                row[2] = item.Date.ToLongDateString() + " " + item.Date.ToLongTimeString();
                ListViewItem listViewItem = new ListViewItem(row);
                listViewItem.Name = item.ID.ToString();
                objects.mailListView.Items.Add(listViewItem);
            }

            int csw = objects.mailListView.ClientSize.Width;

            for (int i = 1; i < objects.mailListView.Columns.Count; i++)
            {
                objects.mailListView.Columns[i].Width = -1;
                csw -= objects.mailListView.Columns[i].Width;
            }

            objects.mailListView.Columns[0].Width = csw;
        }

        public void AddEventHandlers()
        {
            objects.mailListView.Click += new EventHandler(MailListViewEvent_Click);
        }

        private void MailListViewEvent_Click(object sender, EventArgs e)
        {
            if (objects.mailListView.SelectedItems.Count != 0)
            {
                selectedItem = objects.mailListView.SelectedItems[0];
            }
            DisplayMailContent();
        }
    }
}
