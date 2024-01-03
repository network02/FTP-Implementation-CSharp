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
        private bool isSendingFile = false;
        private string currentStreamedFile;
        private string localFileDirectory;
        private int currentFileSize;
        public UserPage(Socket _sck)
        {
            InitializeComponent();
            this.sck = _sck;
            ClientRequest request = new ClientRequest();
            request.command="LIST";
            request.serverDirectory=ServerDirectory.Text;
            SendObjectInSocket(request);
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
                        SetConsole(response);

                    });
                    break;
                case "CDUP":
                    Invoke((MethodInvoker)delegate
                    {
                        SetConsole(response);
                    });
                    break;
                case "RETR":
                    if (response.statusCode==200)
                    {
                        isGettingFile= true;
                        currentStreamedFile= response.response;
                        currentFileSize= response.fileSize;
                    }
                    else
                    {
                        MessageBox.Show(response.response);
                    }
                        break;
                case "PWD":
                    Invoke((MethodInvoker)delegate
                    {
                        Console.Items.Clear();
                        Console.Items.Add(response.response);
                    });
                    break;
                case "STOR":
                    if (response.statusCode==200)
                    {
                        if (isSendingFile)
                        {
                            MessageBox.Show(response.response);
                            isSendingFile= false;
                        }
                        else
                        {
                            byte[] fileBuffer = File.ReadAllBytes(localFileDirectory);
                            sck.Send(fileBuffer, 0, fileBuffer.Length, SocketFlags.None);
                            isSendingFile=true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.response);
                        isSendingFile= false;
                    }
                    break;
                default:
                    MessageBox.Show(response.response);
                    break;
            }
        }

        private void SetConsole(ServerResponse response)
        {
            if (response.statusCode==200)
            {
                string[] infos = response.response.Split('\n');
                Console.Items.Clear();
                foreach (var info in infos)
                    Console.Items.Add(info);
            }
            else
                MessageBox.Show(response.response);
        }

        private void GetFileButton_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.command="RETR";
            request.serverDirectory=SeverGetFileDir.Text;
            SendObjectInSocket(request);
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
            SendObjectInSocket(request);
        }

        private void ViewFiles_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.command="LIST";
            request.serverDirectory=ServerDirectory.Text;
            SendObjectInSocket(request);
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
                SendObjectInSocket(request);
                this.Enabled=true;
            }
            else
                this.Enabled=true;
            
        }

        private void NewDir_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.command="MKD";
            request.serverDirectory= ServerDirectory.Text;
            SendObjectInSocket(request);
        }

        private void SendObjectInSocket(ClientRequest request)
        {
            string postText = JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(postText);
            sck.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void GetCurrentDirectory_Click(object sender, EventArgs e)
        {
            ClientRequest request = new ClientRequest();
            request.command="PWD";
            SendObjectInSocket(request);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientRequest request= new ClientRequest();
            request.command="CDUP";
            SendObjectInSocket(request);
        }

        private void Quit()
        {
            while(!isSendingFile && !isGettingFile)
            {
                ClientRequest request=new ClientRequest();
                request.command="QUIT";
                SendObjectInSocket(request);
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            new Thread(Quit).Start();
        }
    }
}
