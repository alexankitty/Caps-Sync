using System.Net;
using System.Net.Sockets;

namespace Caps_Sync
{
    public class Network
    {

        public static string _localIP = getIP();

        public static string localIP
        {
            get
            {
                return _localIP;
            }
        }

        //public static Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));

        public static string getIP()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                socket.Close();
            }
            return localIP;
        }
    }
}
