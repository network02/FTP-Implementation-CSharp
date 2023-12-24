using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    internal class Listener
    {
        public int port { get;private set; }
        public Socket sck { get; private set; }
        public bool isListening { get; private set; }

        public Listener(int _port)
        {
            this.port = _port;
            sck=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
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
            if (OnSocketAccepeted!=null)
                OnSocketAccepeted(e);

            this.sck.BeginAccept(Callback, null);
            
        }

        public delegate void SocketAccepetedHandler(Socket e);
        public event SocketAccepetedHandler OnSocketAccepeted;
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
