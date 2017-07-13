using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MailClient
{
    class UserControl
    {
        private string pathToFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\Data\credentials.txt");


        public string[] ReadCredentials()
        {
            string[] credentials;
            if (File.Exists(pathToFile))
            {
                File.Decrypt(pathToFile);
                credentials = File.ReadAllLines(pathToFile);
                File.Encrypt(pathToFile);
                return credentials;
            }
            else
            {
                credentials = MailVisualObjects.LoginDialog();
            }
            return credentials;
        }

        public void DeleteCredentials()
        {
            if (File.Exists(pathToFile))
            {
                File.Delete(pathToFile);
                MessageBox.Show("Credentials successfully deleted.");
            }
            else { MessageBox.Show("No credentials to delete."); }
        }

        public void SaveCredentials(string[] credentials)
        {
            if (credentials[0] != "" && credentials[1] != "")
            {
                // saving credentials to a file; the program will try to parse it the next time it runs
                try
                {
                    File.WriteAllLines(pathToFile, credentials);
                    File.Encrypt(pathToFile);
                    MessageBox.Show("Credentials saved successfully.");
                }
                catch { MessageBox.Show("Something went wrong. Please try entering your credentials again."); };
            }
            else { MessageBox.Show("Something went wrong. Please try entering your credentials again."); }
        }
    }
}
