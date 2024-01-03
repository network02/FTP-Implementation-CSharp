using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace FTP
{
    internal class Listener
    {
        #region Socket Values
        public int port { get;private set; }
        public Socket sck { get; private set; }
        public bool isListening { get; private set; }

        #endregion
        #region User Info Values
        public Dictionary<string, UserInfo> userInfo { get; private set; }
        public Dictionary<string, bool> logs { get; private set; }
        #endregion
        #region File Values
        private string rootPath = "E:\\Server\\Root";
        private bool isGettingFile = false;
        private string currentStreamedFileName;
        private string currentChosenDirectory;
        private int fileSize;
        #endregion

        #region Server Values
        private static ThreadLocal<string> currentServerDirectory= new ThreadLocal<string>();
        private static ThreadLocal<UserInfo> currentUser= new ThreadLocal<UserInfo>();
        #endregion
        public Listener(int _port, Dictionary<string, UserInfo> info)
        {
            this.port = _port;
            sck=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.userInfo=info;
            logs=new Dictionary<string, bool>();
        }

        public void Start()
        {
            if(isListening)
                return;

            isListening = true;
            sck.Bind(new IPEndPoint(0, port));
            sck.Listen(0);

            sck.BeginAccept(Callback, null);

        }
        private void Callback(IAsyncResult ar)
        {
            Socket e=this.sck.EndAccept(ar);
            new Thread(() =>
            {
                currentServerDirectory.Value=rootPath;
                ReadData(e);
            }).Start();
            if (OnSocketAccepeted!=null)
                OnSocketAccepeted(e);

            this.sck.BeginAccept(Callback, null);
            
        }
        public delegate void SocketAccepetedHandler(Socket e);
        public event SocketAccepetedHandler OnSocketAccepeted;

        private void ReadData(Socket acp)
        {
            while (true)
            {
                if (isGettingFile)
                    ReadFile(acp);
                else
                    ReadObject(acp);
            }
        }

        private void ReadFile(Socket acp)
        {
            byte[] buffer = new byte[fileSize];
            int bufferSize = acp.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            if (bufferSize<0)
                Thread.CurrentThread.Abort();
            File.WriteAllBytes(currentChosenDirectory, buffer);
            isGettingFile=false;
            ServerResponse response=new ServerResponse();
            response.response="File Sent";
            response.statusCode=200;
            response.command="STOR";
            string resJSON=JsonSerializer.Serialize(response);
            byte[] bufffer=Encoding.UTF8.GetBytes(resJSON);
            acp.Send(bufffer,0,bufffer.Length,SocketFlags.None);
        }

        private void ReadObject(Socket acp)
        {
            byte[] buffer = new byte[255];
            int bufferSize = acp.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            if (bufferSize<=0)
                Thread.CurrentThread.Abort();

            Array.Resize(ref buffer, bufferSize);

            string clientRequest = Encoding.UTF8.GetString(buffer);
            ClientRequest request = JsonSerializer.Deserialize<ClientRequest>(clientRequest);
            ServerResponse response = new ServerResponse();
            string path;
            switch (request.command)
            {
                case "USER":
                    response = Login(request);
                    SendObjectToSocket(acp, request, response);
                    break;
                case "LIST":
                    path=Path.Combine(currentServerDirectory.Value, request.serverDirectory);
                    response.response="";
                    try
                    {
                        response.statusCode=200;
                        DirectoryInfo directory = new DirectoryInfo(path);
                        FileInfo[] files = directory.GetFiles();
                        DirectoryInfo[] directories=directory.GetDirectories();
                        
                        for (int i = 0; i<directories.Length; i++)
                        {
                            response.response+= directories[i].CreationTime+" | "+ directories[i].Name+"\n";
                        }
                        for (int i = 0; i<files.Length; i++)
                        {
                            response.response+= files[i].CreationTime+" | "+files[i].Name+"\n";
                        }       
                        currentServerDirectory.Value=path;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        response.statusCode=400;
                        response.response="This directory Doesn't exist";
                    }
                    catch(System.IO.IOException)
                    {
                        response.statusCode=200;
                        var fileInfo=new FileInfo(path);
                        response.response+="Name: "+fileInfo.Name+"\nSize: "+fileInfo.Length+"\nCreation Time: "+fileInfo.CreationTime+"\n";
                    }
                    SendObjectToSocket(acp, request, response);
                    break;
                case "RETR":
                    try
                    {
                        path=Path.Combine(currentServerDirectory.Value, request.serverDirectory);
                        byte[] fileBuffer = File.ReadAllBytes(path);
                        response.statusCode= 200;
                        response.fileSize= fileBuffer.Length;
                        string[] names = request.serverDirectory.Split('\\');
                        response.response=names[names.Length-1];
                        SendObjectToSocket(acp, request, response);
                        acp.Send(fileBuffer, 0, fileBuffer.Length, SocketFlags.None);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        response.statusCode=404;
                        response.response="Invalid Directory";
                        SendObjectToSocket(acp, request, response);
                    }
                    catch
                    {
                        response.statusCode=400;
                        response.response="Unknown Error";
                        SendObjectToSocket(acp, request, response);
                    }
                    break;
                case "STOR":
                    if (!currentUser.Value.adminAccess)
                    {
                        response.statusCode=100;
                        response.response="This user doesn't have the right access";
                        SendObjectToSocket(acp, request, response);
                        break;
                    }
                    try
                    {
                        isGettingFile= true;
                        string[] paths = request.serverDirectory.Split('\n');
                        currentChosenDirectory=Path.Combine(currentServerDirectory.Value, paths[0]);
                        string[] folders = paths[1].Split('\\');
                        fileSize=request.fileSize;
                        currentStreamedFileName= folders[folders.Length-1];
                        currentChosenDirectory=Path.Combine(currentChosenDirectory, currentStreamedFileName);
                    }
                    catch
                    {
                        isGettingFile= false;
                        response.statusCode=404;
                        response.response="Invalid Path";
                        SendObjectToSocket (acp, request, response);
                    }

                    break;
                case "DELETE":
                    if(!currentUser.Value.adminAccess) 
                    {
                        response.statusCode=100;
                        response.response="This user doesn't have the right access";
                        SendObjectToSocket(acp, request, response);
                        break;
                    }
                    string chosenPath = Path.Combine(currentServerDirectory.Value, request.serverDirectory);
                    try
                    {
                        Directory.Delete(chosenPath, true);
                        response.response="Directory Deleted";
                    }
                    catch (DirectoryNotFoundException)
                    {
                        response.statusCode=400;
                        response.response="This file or directory doesn't exist";
                    }
                    catch (System.IO.IOException)
                    {
                        File.Delete(chosenPath);
                        response.response="File Deleted";
                    }
                    SendObjectToSocket(acp,request,response);
                    break;
                case "MKD":
                    if (!currentUser.Value.adminAccess)
                    {
                        response.statusCode=100;
                        response.response="This user doesn't have the right access";
                        SendObjectToSocket(acp, request, response);
                        break;
                    }

                    string pth=Path.Combine(rootPath,request.serverDirectory);
                    try
                    {
                        if(Directory.Exists(pth))
                        {
                            response.response="This Directory already exists";
                            response.statusCode=400;
                        }
                        else
                        {
                            Directory.CreateDirectory(pth);
                            response.response="Directory Created";
                            response.statusCode= 200;
                        }
                    }
                    catch
                    {
                        response.statusCode=400;
                        response.response="Invalid Directory Configuration";
                    }
                    SendObjectToSocket(acp,request,response);
                    break;
                case "PWD":
                    response.statusCode=200;
                    response.response=currentServerDirectory.Value;
                    SendObjectToSocket(acp,request,response);
                    break;
                case "CDUP":
                    if (currentServerDirectory.Value==rootPath)
                    {
                        response.statusCode=128;
                        response.response="You can't move past root directory";
                    }
                    else
                    {
                        response.statusCode= 200;
                        DirectoryInfo directory=Directory.GetParent(currentServerDirectory.Value);
                        FileInfo[] files = directory.GetFiles();
                        DirectoryInfo[] directories = directory.GetDirectories();
                        currentServerDirectory.Value=directory.FullName;
                        for (int i = 0; i<directories.Length; i++)
                        {
                            response.response+= directories[i].CreationTime+" | "+ directories[i].Name+"\n";
                        }
                        for (int i = 0; i<files.Length; i++)
                        {
                            response.response+= files[i].CreationTime+" | "+files[i].Name+"\n";
                        }

                    }
                    SendObjectToSocket(acp,request,response);
                    break;
                case "QUIT":
                    acp.Close();
                    acp.Dispose();
                    Thread.CurrentThread.Abort();
                    break;
            }
        }

        private static void SendObjectToSocket(Socket acp, ClientRequest request, ServerResponse response)
        {
            response.command=request.command;
            string resJson = JsonSerializer.Serialize(response);
            byte[] sendBuffer = Encoding.UTF8.GetBytes(resJson);
            acp.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
            if (response.statusCode!=200 && response.command=="USER")
            {
                acp.Disconnect(true);
            }
        }

        private ServerResponse Login(ClientRequest request)
        {
            ServerResponse response = new ServerResponse();
            UserInfo info = CheckLogin(request.userInfo);
            if (info==null || info.password!= request.userInfo.password)
            {
                response.statusCode=404;
                response.response="Invalid Username or Password";
            }
            else
            {
                logs.TryGetValue(request.userInfo.username, out bool log); 
                if (!log)
                {
                    response.statusCode=200;
                    response.response="User was Logged in successfully";
                    logs.Add(request.userInfo.username, true);
                    currentUser.Value=info;
                }
                else if (log==true)
                {
                    response.statusCode=403;
                    response.response="User is already logged in";
                }

            }


            return response;
        }

        private UserInfo CheckLogin(UserInfo _info)
        {
            userInfo.TryGetValue(_info.username, out UserInfo value);
            
            return value;
        }

        
        public void Stop()
        {
            if(!isListening)
                return;

            isListening = false;
            sck.Close();
            sck.Dispose();
            sck=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
