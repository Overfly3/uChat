﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace uChat_Client.Entities
{
    [Serializable]
    public enum PacketType
    {
        Login
    }
    [Serializable]
    public class Packet
    {
        public PacketType PacketType { get; set; }
        public string Message { get; set; }
        public string SenderIP { get; set; }
        public string ReceiverIP { get; set; }
    }
}
