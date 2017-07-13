using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    class UserControl
    {
        public void SaveCredentials(string email, string password)
        {
            // saving credentials to a file; authenticate will get it from there
        }

        public bool AuthenticateUser(string email, string password)
        {
            return false;
        }
    }
}
