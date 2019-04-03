using System;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Threading;

namespace Caps_Sync
{
    class Client
    {

        public static bool connected = false;

        private static void Reconnect(bool reconnecting = true) {

            if (connected)
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
            }
            _clientSocket.Close();
            clientInitialized = false;
            if (reconnecting && Settings.Mode == "Client")
            {
                ConnectToServer();
            }
        }

        public static bool clientInitialized = false;

        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] _asyncbuffer = new byte[1024]; //Creates a new asynchronous buffer of 1kb

        public static string ServerString
        {
            get
            {
                return Settings.IP + ":" + Settings.Port;
            }
        }


        public static void ConnectToServer()
        {
            if (!clientInitialized)
            {
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            Logging.Write(String.Format("Connecting to {0}.", ServerString), 3);
            _clientSocket.BeginConnect(Settings.IP, Settings.Port, new AsyncCallback(ConnectCallback), _clientSocket);
            clientInitialized = true;
        }

        public static void RemoveClient()
        {
            Logging.Write("The client is going down - NOW!", 3);
            Reconnect(false);
            Logging.Write("The Client functions have been disabled!", 3);
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndConnect(ar);
            }
            catch(ArgumentException)
            {
                Logging.Write("The server has unexpectedly disconnected and the resulting Async Callback has been cancelled.", 2);
                return;
            }
            catch(ObjectDisposedException)
            {
                Logging.Write("Current Async connection started from BeginConnect has been terminated. This is most likely caused by changing the program into Server mode (ignorable in this case).", 3);
                return;
            }
            catch(SocketException)
            {
                Logging.Write("Connection failed.", 3);
                Reconnect();
                return;
                //while (!connected && clientInitialized)
                //{
                //    try
                //    {
                //        _clientSocket.Connect(Settings.IP, Settings.Port);
                //    }
                //    catch(SocketException)
                //    {
                //        Logging.Write(String.Format("Connection to {0} failed.", ServerString), 3);
                //    }
                //    catch(InvalidOperationException)
                //    {
                //        Logging.Write("Socket disconnected, resetting", 2);
                //        Reconnect();
                //        return;
                //    }
                //    Logging.Write(String.Format("Is Client initialized? {0}", clientInitialized), 4);
                //}
            }
            connected = true;
            while (connected)
            {
                OnReceive();
            }
        }

        private static void OnReceive()
        {//reminder that stream sends as much info as possible before it actually performs the send.
            byte[] _sizeinfo = new byte[4];
            byte[] _receivedbuffer = new byte[1024];
            int totalread = 0, currentread = 0;
            try
            {
                currentread = totalread = _clientSocket.Receive(_sizeinfo);
                if (totalread <= 0)
                {
                    Logging.Write("Server no longer responding: Disconnected.", 3);
                    connected = false;
                    Reconnect();
                    return;
                }
                else
                {
                    while (totalread < _sizeinfo.Length && currentread > 0)
                    {
                        currentread = _clientSocket.Receive(_sizeinfo, totalread, _sizeinfo.Length - totalread, SocketFlags.None);
                        totalread += currentread;
                    }

                    int messagesize = 0;
                    messagesize |= _sizeinfo[0];
                    messagesize |= (_sizeinfo[1] << 8);
                    messagesize |= (_sizeinfo[2] << 16);
                    messagesize |= (_sizeinfo[3] << 24); //bitshift the bytes.

                    byte[] data = new byte[messagesize];

                    totalread = 0;
                    currentread = totalread = _clientSocket.Receive(data, totalread, data.Length - totalread, SocketFlags.None);
                    while (totalread < messagesize && currentread > 0)
                    {
                        currentread = _clientSocket.Receive(data, totalread, data.Length - totalread, SocketFlags.None);
                        totalread += currentread;
                    }
                    //handlednetworkinformation
                    ClientHandleNetworkData.HandleNetworkInformation(data);
                }
            }
            catch(SocketException) {
                Logging.Write("Server socket has unexpectedly closed. Retrying the connection.", 1);
                connected = false;
                Reconnect();
                return;
            }

        }

        public static void SendData(byte[] data)
        {
            _clientSocket.Send(data);
        }

        public static void ServerACK()
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write((int)ClientPackets.ClientACK);
            buffer.Write("Ready to send Caps State.");
            SendData(buffer.ToArray());
            buffer.Dispose();
        }

        public static void SendCaps(string state) {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write((int)ClientPackets.CapsChanged);
            buffer.Write(state);
            SendData(buffer.ToArray());
            buffer.Dispose();
        }

    }
}