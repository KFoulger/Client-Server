using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace locationserver
{
    public partial class serverInterface : Form
    {
        public serverInterface()
        {
            InitializeComponent();
        }
        int iPort;
        int iTimeout;
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
        //(21-25) Closes the UI and the server
        private void runButton_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            if(portBox.Text.ToString() == null)
            {
                iPort = 43;
            }
            else
            {
                iPort = int.Parse(portBox.Text.ToString());
            }
            //(30-37) Checks if there is anything in the port box. If not it is defaulted to 43.
            if(timeoutBox.Text.ToString() == null)
            {
                iTimeout = 1000;
            }
            else
            {
                iTimeout = int.Parse(timeoutBox.Text.ToString());
            }
            //(39-46) Checks if there is anything in the timeout box. If not it is defaulted to 1000
            Server.RunServer(iPort, iTimeout); //Sends the port and timeout numbers to the server and runs it
            Close();
        }

        private void infoPort_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This changes the port that the server is listening to. Eg/ 80.\r\nDefaults to 43");
        }

        private void infoTimeout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This changes the timeout of the server in milliseconds (1000ms = 1s). Eg/2000.\r\nDefaults to 1000");
        }
        //(52-60) Shows information if the 'i' boxes are clicked
    }
}
