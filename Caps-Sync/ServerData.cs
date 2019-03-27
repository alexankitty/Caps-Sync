using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caps_Sync
{
    class ServerHandleNetworkData
    {
        private delegate void PacketTypes(int index, byte[] data);
        private static Dictionary<int, PacketTypes> Packets;

        public static void HandleNetworkInformation(int index, byte[] data)
        {
            int packetnum; PacketBuffer buffer = new PacketBuffer();
            buffer.Write(data);
            packetnum = buffer.ReadtoInteger();
            buffer.Dispose();
            if (Packets.TryGetValue(packetnum, out PacketTypes Packet))
            {
                Packet.Invoke(index, data);
            }
        }
        
        public static void InitializeNetworkPackages()
        {
            Packets = new Dictionary<int, PacketTypes> {
            {(int)ClientPackets.ClientACK, HandleConnectionOK },
            {(int)ClientPackets.CapsChanged, CapsReceive }
            };
        }

        private static void HandleConnectionOK(int index, byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write(data);
            /*int packetnum = */
            buffer.ReadtoInteger();
            string msg = buffer.ReadtoString();
            buffer.Dispose();
            //Add code to be executed here.
            Console.WriteLine(msg);
        }

        private static void CapsReceive(int index, byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write(data);
            buffer.ReadtoInteger();
            string state = buffer.ReadtoString();
            buffer.Dispose();
            Console.WriteLine("Received Caps state: {0}", state);
            switch(state)
            {
                case "ON":
                    KeyHandler.SynchronizeCapsState(true);
                    Server.SendCapsChanged(index, state);
                    break;
                case "OFF":
                    KeyHandler.SynchronizeCapsState(false);
                    Server.SendCapsChanged(index, state);
                    break;
                default:
                    Console.WriteLine("Bad data received: {0}", state);
                    break;
            }

        }
    }
}
