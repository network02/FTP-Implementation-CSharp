
namespace FTP
{
    internal class ServerResponse
    {
        public int statusCode { get; set; }
        public string response { get; set; }
        public string command { get; set; }
        public int fileSize { get; set; }
    }
}
