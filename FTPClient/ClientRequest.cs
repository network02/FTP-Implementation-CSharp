using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    internal class ClientRequest
    {
        public string requestType { get; set; }
        public string requestHeader { get; set; }
        public UserInfo userInfo { get; set; }
        public string command { get; set; }
        public string serverDirectory { get; set; }
        
    }
    
}
