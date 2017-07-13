using System;
using System.Windows.Forms;
using System.Threading;

namespace MailClient
{
    public partial class MailClientForm : Form
    {
        ObjectControl objectController = new ObjectControl();
        UserControl userController = new UserControl();


        public MailClientForm()
        {
            InitializeComponent();
            objectController.objects.Setup();
            objectController.AddEventHandlers();

            Controls.Add(objectController.objects.mailListView);
            Controls.Add(objectController.objects.contentBox);

            objectController.SetCredentials(userController.ReadCredentials());
            objectController.ListMails();
        }

        private void MailClientForm_Load(object sender, EventArgs e)
        {
            GetMailTimer.Start();
        }

        private void GetMailTimer_Tick(object sender, EventArgs e)
        {
            objectController.ListMails();
            GetMailTimer.Interval = 10000;
            Text = "SaintSender - " + objectController.GetCredentials()[0];
        }

        private void saveCredsButton_Click(object sender, EventArgs e)
        {
            userController.SaveCredentials(objectController.GetCredentials());
        }

        private void deleteCredsButton_Click(object sender, EventArgs e)
        {
            userController.DeleteCredentials();
        }

        private void sendMailButton_Click(object sender, EventArgs e)
        {
            objectController.mailController.connection.SendMail();
        }
    }
}
