using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;

namespace FTPClient
{
    public partial class Client : Form
    {
        Socket sck;
        public Client()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            int portNum = 0;
            IPAddress address=null;
            try
            {
                portNum=Int32.Parse(Port_Input.Text);
                IPAddress.TryParse(IP_Input.Text, out address);
            }
            catch 
            {
                MessageBox.Show("Invalid Port");
            }

            ClientRequest clientRequest= new ClientRequest();
            clientRequest.requestHeader="Content-Type: Application/json";
            clientRequest.requestType="POST";
            clientRequest.userInfo=new UserInfo();
            clientRequest.userInfo.username=Username_Input.Text;
            clientRequest.userInfo.password=Password_Input.Text;
            clientRequest.command="USER";

            string userPacket = JsonSerializer.Serialize(clientRequest);
            
            sck=Socket_Init();
            try
            {
                sck.Connect(new IPEndPoint(address, portNum));
            }
            catch
            {
                MessageBox.Show("Connection failed");
            }
            sck.Send(Encoding.UTF8.GetBytes(userPacket));

            new Thread(() =>
            {
                ReadData();
            }).Start();
            
        }
        private void ReadData()
        {
            while (true)
            {
                byte[] buffer = new byte[255];
                int bufferSize = sck.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                if (bufferSize<=0)
                    Thread.CurrentThread.Abort();

                Array.Resize(ref buffer, bufferSize);
                string response= Encoding.UTF8.GetString(buffer);
                ServerResponse serverResponse=JsonSerializer.Deserialize<ServerResponse>(response);
                if (serverResponse.statusCode==200 && serverResponse.command=="USER")
                {
                    MessageBox.Show(serverResponse.response);
                    break;
                }
            }
            Invoke((MethodInvoker)delegate {
                this.Hide();
                UserPage userPage = new UserPage(sck);
                userPage.FormClosed+=(s, args) => this.Close();
                userPage.Show();
            });
            Thread.CurrentThread.Abort();

        }
        private Socket Socket_Init()=>new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
    }
}
