using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class MailClientForm : Form
    {
        MailControl mailController = new MailControl();

        public MailClientForm()
        {
            InitializeComponent();
        }

        private void MailClientForm_Load(object sender, EventArgs e)
        {
            mailController.mailBox = MailServerConnection.Connect();

            mailController.mailListBox.Setup();
            Controls.Add(mailController.mailListBox.mailListView);
            mailController.contentBox.Setup();
            Controls.Add(mailController.contentBox.contentBox);

            mailController.ListMails();
        }
    }
}
