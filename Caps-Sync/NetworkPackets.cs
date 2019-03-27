using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caps_Sync
{
    //Server to Client
    public enum ServerPackets
    {
        SConnectionOK = 1,
        CapsReflected = 2
    }
    //Client to Server
    public enum ClientPackets
    {
        ClientACK = 1,
        CapsChanged = 2,
    }
}

