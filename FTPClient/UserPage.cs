using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class UserPage : Form
    {
        private Socket sck;
        private string downPath = "E:\\Client";
        private bool isGettingFile = false;
        private string currentStreamedFile;
        private MemoryStream fs=new MemoryStream();
        public UserPage(Socket _sck)
        {
            InitializeComponent();
            this.sck = _sck;
            new Thread(() =>
            {
                Read();
            }).Start();
        }

        private void ViewFiles_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.command="LIST";
            request.serverDirectory=ServerDirectory.Text;
            string postText = JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(postText);
            sck.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        private void Read()
        {
            while (true)
            {
                if (isGettingFile)
                {
                    byte[] fileBuffer= new byte[1024*5000];
                    int bytesRead = 0;
                    bytesRead=sck.Receive(fileBuffer,0,fileBuffer.Length,SocketFlags.None);
                    if (bytesRead<=0)
                        Thread.CurrentThread.Abort();

                    string filePath = Path.Combine(downPath, currentStreamedFile);
                    File.WriteAllBytes(filePath, fileBuffer);
                    isGettingFile=false;
                }
                else
                {
                    byte[] buffer = new byte[1024*5000];
                    int bufferSize = sck.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    if (bufferSize<=0)
                        break;
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
                        case "RETR":
                            isGettingFile= true;
                            currentStreamedFile= response.response;
                            break;
                    }
                }

                

                
            }
        }

        private void GetFileButton_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.command="RETR";
            request.serverDirectory=SeverGetFileDir.Text;
            string postText=JsonSerializer.Serialize(request);
            byte[]buffer=Encoding.UTF8.GetBytes(postText);
            sck.Send(buffer,0,buffer.Length, SocketFlags.None);
        }
    }
}
