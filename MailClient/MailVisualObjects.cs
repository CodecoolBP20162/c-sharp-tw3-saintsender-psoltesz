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
            contentBox.Bounds = new Rectangle(new Point(700, 33), new Size(400, 509));
            contentBox.Multiline = true;
            contentBox.ScrollBars = ScrollBars.Vertical;

            mailListView.Bounds = new Rectangle(new Point(25, 33), new Size(500, 509));
            mailListView.FullRowSelect = true;
            mailListView.View = View.Details;
            mailListView.AllowColumnReorder = true;
            mailListView.Columns.Add("From");
            mailListView.Columns.Add("Subject");
            mailListView.Columns.Add("Date");

            // implement loading labels maybe?
        }

        public string[] LoginDialog()
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
            loginButton.Click += (sender, e) => { newDialog.Close(); };
            exitButton.Click += (sender, e) => { Application.Exit(); };

            newDialog.Controls.Add(loginButton);
            newDialog.Controls.Add(exitButton);
            newDialog.Controls.Add(textLabel);
            newDialog.Controls.Add(email);
            newDialog.Controls.Add(password);
            newDialog.ShowDialog();
            string[] result = new string[2] { email.Text, password.Text };
            return result;
        }
    }
}
