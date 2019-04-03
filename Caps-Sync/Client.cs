using System;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Threading;

namespace Caps_Sync
{
    class Client
    {

        public static bool connected
        {
            get
            {
                return _clientSocket.Connected;
            }
        }

        public static bool connectedFunc()
        {
            return connected;
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
            Logging.Write(String.Format("Connecting to {0}", ServerString), 3);
            _clientSocket.BeginConnect(Settings.IP, Settings.Port, new AsyncCallback(ConnectCallback), _clientSocket);
            clientInitialized = true;
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndConnect(ar);
            }
            catch(SocketException)
            {
                
                Logging.Write(String.Format("Connection to {0} failed.", ServerString), 3);
                while (!_clientSocket.Connected)
                {
                    Thread.Sleep(500);
                    try
                    {
                        _clientSocket.Connect(Settings.IP, Settings.Port);
                    }
                    catch(SocketException)
                    {
                        Logging.Write(String.Format("Connection to {0} failed.", ServerString), 3);
                        continue;
                    }
                }
            }
            while (_clientSocket.Connected)
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
            catch(Exception e) {
                Logging.ExceptionWrite(e);
                Logging.Write("Exception has been thrown in the server Socket. Closing the socket and retrying the connection.", 1);
                _clientSocket.Close();
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Thread.Sleep(500);
                ConnectToServer();
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