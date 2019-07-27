using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace location
{
    public partial class ClientInterface : Form
    {

        string output = null;
        string protocol = null;
        public ClientInterface()
        {
            InitializeComponent();
        }

        private void closeWindow_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
        //(23-27) Closes the window and client when the close button is clicked
        private void runClient_Click(object sender, EventArgs e)
        {
            bool stop = false;
            locationClient client = new locationClient();
            string[] interfaceData = new string[7];
            if (nameBox.Text.ToString() == "")
            {
                responseBox.Text += "Please enter a name";
                stop = true;
            }
            //(34-38) If the name box is empty the user is prompted to enter a name and a boolean is set for use later
            else
            {
                interfaceData[0] = nameBox.Text.ToString();
            }
            //(40-43) Adds the username to the data array
            if (locationBox.Text.ToString() == "")
            {
                interfaceData[1] = null;
            }
            //(45-48) If no location is set, nothing is added to the array so two variables aren't read later on
            else
            {
                interfaceData[1] = locationBox.Text.ToString();
            }
            //(50-53) Adds the location to the data array
            interfaceData[2] = "-h";
            interfaceData[4] = "-p";
            //(55-56) Adds the host and port identifiers to the array
            if(IPBox.Text.ToString() != "")
            {
                interfaceData[3] = (IPBox.Text.ToString());
            }
            //(58-61) Adds the host name to the array
            else
            {
                interfaceData[3] = ("whois.net.dcs.hull.ac.uk");
            }
            //(63-66) Defaults the host name if nothing is entered in the UI
            if(portBox.Text.ToString() != "")
            {
                interfaceData[5] = (portBox.Text.ToString());
            }
            //(68-71) Adds the port number to the array
            else
            {
                interfaceData[5] = ("43");
            }
            //(73-76) Defaults the port number if nothing is entered in the UI
            interfaceData[6] = (protocol);
            if(stop == true)
            {
                interfaceData[1] = null;
            }
            //(79-82) If the name is null, the location also becomes null so it isn't mistaken for the name
            output = locationClient.runClient(interfaceData);
            responseBox.Text += output;
            //(84-85) runs the client and uses the response to add to the textbox
        }

        private void whoisRadio_CheckedChanged(object sender, EventArgs e)
        {
            protocol = null;
        }

        private void http09Radio_CheckedChanged(object sender, EventArgs e)
        {
            protocol = "-h9";
        }

        private void http10Radio_CheckedChanged(object sender, EventArgs e)
        {
            protocol = "-h0";
        }

        private void http11Radio_CheckedChanged(object sender, EventArgs e)
        {
            protocol = "-h1";
        }
        //(89-107) Changes the protocol variable based on the radio buttons
        private void clearResponse_Click(object sender, EventArgs e)
        {
            responseBox.Clear();
        }
        //(109-112) Clears the response textbox
        private void infoName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter your username here. Eg/ 529353");
        }

        private void infoLocation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter a location here if you want to update it or add a user. Eg/ In Fenner");
        }

        private void infoIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the address of the server you wnat to connect to. Eg/ localhost.\r\nwhois.net.dcs.hull.ac.uk is the default address");
        }

        private void infoPort_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the number of the port you wish to connect through here. Eg/ 80.\r\nPort 43 is the default port");
        }

        private void infoProtocol_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select the protocol you wish to use for server communication.\r\nwhois is the default protocol");
        }
        //(114-137) Shows extra information if the 'i' buttons next to the choices are clicked
    }
}