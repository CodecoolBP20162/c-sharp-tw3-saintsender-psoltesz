using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    class MailContentBox
    {
        public TextBox contentBox = new TextBox();

        public void Setup()
        {
            contentBox.Bounds = new Rectangle(new Point(80, 33), new Size(320, 509));
        }
    }
}
