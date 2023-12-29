using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    internal class ClientRequest
    {
        public UserInfo userInfo { get; set; }
        public string command { get; set; }
        public string serverDirectory { get; set; }
        public int fileSize { get; set; }
        
    }
    
}
