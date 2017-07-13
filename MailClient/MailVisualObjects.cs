using System;
using System.Drawing;
using System.Windows.Forms;

namespace MailClient
{
    class MailVisualObjects
    {
        public ListView mailListView = new ListView();
        public TextBox contentBox = new TextBox();


        public void Setup()
        {
            mailListView.Bounds = new Rectangle(new Point(25, 30), new Size(655, 496));
            mailListView.FullRowSelect = true;
            mailListView.View = View.Details;
            mailListView.AllowColumnReorder = true;
            mailListView.Columns.Add("From");
            mailListView.Columns.Add("Subject");
            mailListView.Columns.Add("Date");

            contentBox.Bounds = new Rectangle(new Point(820, 30), new Size(625, 496));
            contentBox.Multiline = true;
            contentBox.ReadOnly = true;
            contentBox.ScrollBars = ScrollBars.Vertical;
        }

        public static string[] LoginDialog()
        {
            Form newDialog = new Form();
            newDialog.StartPosition = FormStartPosition.CenterParent;
            newDialog.Width = 400;
            newDialog.Height = 300;
            newDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            newDialog.Text = "SaintSender: Log in";
            TextBox email = new TextBox() { Width = 250, Location = new Point(70, 100) };
            TextBox password = new TextBox() { Width = 100, Location = new Point(140, 140) };
            password.PasswordChar = '*';
            newDialog.MinimizeBox = false;
            newDialog.MaximizeBox = false;
            Label textLabel = new Label() { Text = "Please enter your credentials:" };
            textLabel.Dock = DockStyle.Top;
            textLabel.TextAlign = ContentAlignment.MiddleCenter;
            Button loginButton = new Button() { Text = "Log in", Width = 100, Location = new Point(140, 200) };
            Button exitButton = new Button() { Text = "Exit", Width = 100, Location = new Point(140, 230) };

            loginButton.Click += (sender, e) => { newDialog.DialogResult = DialogResult.OK; };
            exitButton.Click += (sender, e) => { Environment.Exit(1); };
            newDialog.FormClosing += (sender, e) => { if (newDialog.DialogResult == DialogResult.Cancel) { Environment.Exit(1); } else { newDialog.DialogResult = DialogResult.OK; } };

            newDialog.Controls.Add(loginButton);
            newDialog.Controls.Add(exitButton);
            newDialog.Controls.Add(textLabel);
            newDialog.Controls.Add(email);
            newDialog.Controls.Add(password);
            newDialog.ShowDialog();
            string[] result = new string[2] { email.Text, password.Text };
            return result;
        }

        public static string[] SendMailDialog()
        {
            Form newDialog = new Form();
            newDialog.StartPosition = FormStartPosition.CenterParent;
            newDialog.Width = 400;
            newDialog.Height = 500;
            newDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            newDialog.Text = "Send an e-mail";

            Label toLabel = new Label() { Text = "To:", Location = new Point(20, 10) };
            TextBox to = new TextBox() { Width = 340, Location = new Point(20, 40) };

            Label subjectLabel = new Label() { Text = "Subject:", Location = new Point(20, 70) };
            TextBox subject = new TextBox() { Width = 340, Location = new Point(20, 100) };

            Label bodyLabel = new Label() { Text = "Message:", Location = new Point(20, 130) };
            TextBox body = new TextBox() { Width = 340, Height = 230, Location = new Point(20, 160) };
            body.Multiline = true;

            newDialog.MinimizeBox = false;
            newDialog.MaximizeBox = false;
            Button sendButton = new Button() { Text = "Send", Width = 100, Location = new Point(140, 400) };
            Button cancelButton = new Button() { Text = "Cancel", Width = 100, Location = new Point(140, 430) };

            sendButton.Click += (sender, e) => { newDialog.DialogResult = DialogResult.OK; };
            cancelButton.Click += (sender, e) => { newDialog.DialogResult = DialogResult.Cancel; };

            newDialog.Controls.Add(toLabel);
            newDialog.Controls.Add(to);
            newDialog.Controls.Add(subjectLabel);
            newDialog.Controls.Add(subject);
            newDialog.Controls.Add(bodyLabel);
            newDialog.Controls.Add(body);
            newDialog.Controls.Add(sendButton);
            newDialog.Controls.Add(cancelButton);
            newDialog.ShowDialog();

            if (newDialog.DialogResult == DialogResult.OK)
            {
                string[] result = new string[3] { to.Text, subject.Text, body.Text };
                return result;
            }
            else { return null; }
        }
    }
}
