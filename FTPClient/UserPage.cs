using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class UserPage : Form
    {
        Socket sck;
        public UserPage(Socket _sck)
        {
            InitializeComponent();
            this.sck = _sck;
        }

        private void ViewFiles_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.requestHeader="Content-Type: application/json";
            request.command="LIST";
            request.serverDirectory=ServerDirectory.Text;
            request.requestType="POST";
            string postText = JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(postText);
            sck.Send(buffer, 0, buffer.Length, SocketFlags.None);

            new Thread(() =>
            {
                Read();
            }).Start();
        }
        private void Read()
        {
            while (true)
            {
                byte[] buffer = new byte[255];
                int bufferSize = sck.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                if (bufferSize<=0)
                    Thread.CurrentThread.Abort();


                Array.Resize(ref buffer, bufferSize);
                string downText = Encoding.UTF8.GetString(buffer);
                ServerResponse response = JsonSerializer.Deserialize<ServerResponse>(downText);
                switch (response.command)
                {
                    case "LIST":
                        Invoke((MethodInvoker)delegate
                        {
                            string[] infos = response.response.Split('\n');
                            Console.Items.Clear();
                            foreach (var info in infos)
                                Console.Items.Add(info);
                        });
                        break;
                }
                
            }
        }
    }
}
