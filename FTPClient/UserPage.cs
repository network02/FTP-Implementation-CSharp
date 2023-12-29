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
        private string localFileDirectory;
        private int currentFileSize;
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

        private void Read()
        {
            while (true)
            {
                if (isGettingFile)
                {
                    ReadFile();
                }
                else
                {
                    ReadObject();
                }
            }
        }

        private void ReadFile()
        {
            byte[] fileBuffer = new byte[currentFileSize];
            int bytesRead = 0;
            bytesRead=sck.Receive(fileBuffer, 0, fileBuffer.Length, SocketFlags.None);
            if (bytesRead<=0)
                Thread.CurrentThread.Abort();
            string filePath = Path.Combine(downPath, currentStreamedFile);
            File.WriteAllBytes(filePath, fileBuffer);
            isGettingFile=false;
            MessageBox.Show("File Received");
        }

        private void ReadObject()
        {
            byte[] buffer = new byte[1024];
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
                case "RETR":
                    isGettingFile= true;
                    currentStreamedFile= response.response;
                    currentFileSize= response.fileSize;
                    break;
                case "DELETE":
                    MessageBox.Show(response.response);
                    break;
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

        private void Brows_Click(object sender, EventArgs e)
        {
            var browseForm=new System.Windows.Forms.OpenFileDialog();

            this.Enabled=false;

            DialogResult result=browseForm.ShowDialog();

            if(result==DialogResult.OK)
            {
                localFileDirectory= browseForm.FileName;
                ClientDir.Text=localFileDirectory;
                this.Enabled=true;
            }
            else if (result==DialogResult.Cancel)
            {
                this.Enabled=true;
            }
            
        }

        private void SendFile_Click(object sender, EventArgs e)
        {
            ClientRequest request=new ClientRequest();
            byte[] fileBuffer = File.ReadAllBytes(localFileDirectory);
            request.command="STOR";
            request.serverDirectory= ServerSendFileDir.Text +'\n'+localFileDirectory;
            request.fileSize= fileBuffer.Length;
            string postText=JsonSerializer.Serialize(request);
            byte[]buffer= Encoding.UTF8.GetBytes(postText);
            sck.Send(buffer,0,buffer.Length, SocketFlags.None);
            sck.Send(fileBuffer,0,fileBuffer.Length, SocketFlags.None);
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Are you Sure?", "Confirm", MessageBoxButtons.YesNo);
            this.Enabled= false;
            if(result == DialogResult.Yes)
            {
                ClientRequest request = new ClientRequest();
                request.command="DELETE";
                request.serverDirectory= ServerDirectory.Text;
                string postText = JsonSerializer.Serialize(request);
                byte[] buffer = Encoding.UTF8.GetBytes(postText);
                sck.Send(buffer, 0, buffer.Length, SocketFlags.None);
                this.Enabled=true;
            }
            else
                this.Enabled=true;
            
        }
    }
}
