using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace FTP
{
    public partial class Form1 : Form
    {
        Listener listener;
        List<Socket> sockets;
        Dictionary<string, UserInfo> users;
        public Form1()
        {
            InitializeComponent();
            sockets= new List<Socket>();
            users= new Dictionary<string, UserInfo>();
            ReadDatabase();
        }
        private void ReadDatabase()
        {
            try
            {
                string usersData = System.IO.File.ReadAllText("E:\\CPP\\FTP\\Data\\Users.json");
                users=JsonSerializer.Deserialize<Dictionary<string, UserInfo>>(usersData);
            }
            catch
            {
                MessageBox.Show("Error while accessing the database");
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            int portNumber = 0;
            try
            {
                portNumber=Int32.Parse(PortInput.Text);
            }
            catch 
            {
                MessageBox.Show("Invalid Entry");
                return;
            }
            listener=new Listener(portNumber);
            listener.OnSocketAccepeted += new Listener.SocketAccepetedHandler(listenerSocketAccpeted);
            listener.Start();
            MessageBox.Show("Server is Listening");
        }
        private void listenerSocketAccpeted(Socket e)
        {
            sockets.Add(e);
        }

        private void AddUser_Click(object sender, EventArgs e)
        {

            Admin adminForm= new Admin();
            DialogResult result =adminForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                users=JsonSerializer.Deserialize<Dictionary<string, UserInfo>>(adminForm.dataJson);
            }
        }
    }
}
