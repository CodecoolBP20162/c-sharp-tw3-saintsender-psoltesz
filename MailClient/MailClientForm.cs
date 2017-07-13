using System;
using System.Windows.Forms;

namespace MailClient
{
    public partial class MailClientForm : Form
    {
        ObjectControl objectController = new ObjectControl();

        public MailClientForm()
        {
            InitializeComponent();
            objectController.objects.Setup();
            objectController.AddEventHandlers();

            Controls.Add(objectController.objects.mailListView);
            Controls.Add(objectController.objects.contentBox);

            objectController.ListMails();
            GetMailTimer.Start();
        }

        private void GetMailTimer_Tick(object sender, EventArgs e)
        {
            objectController.ListMails();
        }

        private void MailClientForm_Load(object sender, EventArgs e)
        {
            string[] credentials = objectController.objects.LoginDialog();
            // SaveCredentials();
            // AuthenticateUser();
        }
    }
}
