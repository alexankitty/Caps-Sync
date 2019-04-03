using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Caps_Sync
{
    class Server {
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Creates the Stream type TCP Socket
        private static byte[] _buffer = new byte[1024]; // Creates a buffer.
        public static ServeClient[] _clients = new ServeClient[Constants.MAX_Clients]; //Creates the client with the maximum number specified.

        public static string ServerIP
        {
            get
            {
                return Network.localIP;
            }

        }
        public static string ServerString
        {
            get
            {
                return ServerIP + ":" + Settings.Port;
            }
        }

        public static bool Setup = false;

        public static void SendDataTo(int index, byte[] data)
        {
            byte[] sizeinfo = new byte[4];
            sizeinfo[0] = (byte)data.Length;
            sizeinfo[1] = (byte)(data.Length >> 8); //Bit shifts
            sizeinfo[2] = (byte)(data.Length >> 16);
            sizeinfo[3] = (byte)(data.Length >> 24); //This sets up the size info byte so the server knows how much data to expect.
            _clients[index].socket.Send(sizeinfo); //This sends the byte size
            _clients[index].socket.Send(data);    //This sends the actual data. Index here is used for the client that the data needs to be sent to.
        }

        public static void SendConnectionOK(int index) //Ensures the connection is made and acknowledged
        {
            PacketBuffer buffer = new PacketBuffer(); //Initializes the packet buffer.
            buffer.Write((int)ServerPackets.SConnectionOK); //Pulls a packet from the enumerator with the name of Server Connection OK
            buffer.Write("Connection Established!"); //Sends a connection success to the connected client.
            SendDataTo(index, buffer.ToArray()); //sends the data to the client within your index.
            buffer.Dispose(); // dispose of your buffer any time you are done with it so we are not flooding the memory with unnecessary data.
        }

    public static void SendCapsChanged(int index, string state)
    {
        PacketBuffer buffer = new PacketBuffer();
        buffer.Write((int)ServerPackets.CapsReflected);
        buffer.Write("Caps has been changed to " + state);
        SendDataTo(index, buffer.ToArray());
        buffer.Dispose();
    }

        public static void SetupServer() // this will set up the actual server
        {
        Logging.Write("Setting up server.", 3);
            for(int i = 0; i < Constants.MAX_Clients; i++)
            {
                _clients[i] = new ServeClient();
            }
            try
            {
                if (!Setup)
                {
                    _serverSocket.Bind(new IPEndPoint(IPAddress.Any, Settings.Port)); //binds to a socket and port
                    _serverSocket.Listen(10); //sets the max amount of clients it will listen for - when the server runs in client mode, this should only accept 1.
                    _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null); //Begins the accept process followed by a callback
                }
                Setup = true;
            }
            catch(SocketException e)
            {
                Logging.ExceptionWrite(e);
                Logging.Write("Server setup has failed, sleeping then trying again.", 2);
                //Thread.Sleep(100);
                //reinitializeServer();
            }
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            Socket socket;
            try
            {
                socket = _serverSocket.EndAccept(ar);/* this terminates the accept connection and then opens it up again for another to connect in. This helps facilitate multiple connections*/
            }
            catch(ArgumentException)
            {
                Logging.Write("Current Async connection started from BeginAccept has been terminated.", 1);
                return;
            }
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

            for (int i = 0; i < Constants.MAX_Clients; i++)
            {
                _clients[i] = new ServeClient(); //creating the client IDs
                if(_clients[i].socket == null) {
                    _clients[i].socket = socket;
                    _clients[i].index = i;
                    _clients[i].IPAddress = socket.RemoteEndPoint.ToString();
                    _clients[i].startClient();
                    Logging.Write(String.Format("Connection from '{0}' received", _clients[i].IPAddress), 3);
                    SendConnectionOK(i);
                    return;
                }
            }
        } 
    }

    class ServeClient
    {
        public int index;
        public string IPAddress;
        public Socket socket;
        public bool closing = false;
        private byte[] _buffer = new byte[1024];

        public void startClient()
        {
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            closing = false;
        }

        private void ReceiveCallback(IAsyncResult ar)
        {

            Socket socket = (Socket)ar.AsyncState;
            /* create a try catch block here to handle a connection being closed unexpectedly. */
            try
            {
                int received = socket.EndReceive(ar); /* this gets the byte length of received data, if no data is received we close the client.*/
                if (received <= 0)
                {
                    CloseClient(index); /*this closes the client of number x*/

                }
                else
                {
                    byte[] databuffer = new byte[received];

                    Array.Copy(_buffer, databuffer, received); /* this part copies the data buffer into a new buffer of the length of the received data */
                                                                //HandleNetworkInformation;
                    ServerHandleNetworkData.HandleNetworkInformation(index, databuffer);
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket); //This opens the server to receiving data, again.
                }
            }
            catch
            {
                CloseClient(index); //This will catch the error and close that connection.
            }
        }

        private void CloseClient(int index)
        {
            closing = true;
            Logging.Write(String.Format("Connection from {0} has been terminated.", IPAddress), 3); //This will close the connection and write the connection closing to the console.                                                                //Client Left
            socket.Close(); //This will free up the socket
        }
    }
}