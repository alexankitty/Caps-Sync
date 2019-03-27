using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caps_Sync
{
    class ClientHandleNetworkData
    {
        private delegate void PacketType(byte[] data);
        private static Dictionary<int, PacketType> Packets;

        public static void HandleNetworkInformation(byte[] data)
        {
            int packetnum;
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write(data);
            packetnum = buffer.ReadtoInteger();
            buffer.Dispose();
            if (Packets.TryGetValue(packetnum, out PacketType Packet))
            {
                Packet.Invoke(data);
            }
        }

        public static void InitializeNetworkPackages()
        {
            Packets = new Dictionary<int, PacketType> {
                {(int)ServerPackets.SConnectionOK, HandleConnectionOK },
                {(int)ServerPackets.CapsReflected, ReceiveCaps }
            };
        }

        private static void HandleConnectionOK(byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write(data);
            buffer.ReadtoInteger(); 
            string msg = buffer.ReadtoString();
            buffer.Dispose();
            //Add code to be executed here.
            Console.WriteLine(msg);
            Client.ServerACK();
        }

        private static void ReceiveCaps(byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write(data);
            buffer.ReadtoInteger();
            string msg = buffer.ReadtoString();
            buffer.Dispose();
            Console.WriteLine(msg);
        }
    }
}
