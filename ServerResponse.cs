using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    internal class ServerResponse
    {
        public int statusCode { get; set; }
        public string response { get; set; }
        public string command { get; set; }
    }
}
