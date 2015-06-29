using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace uChatServer.Entities
{
    public enum PacketType
    {
        Login
    }
    class Packet
    {
        private PacketType myPacketType;
        private string myMessage;
        private IPAddress mySenderIP;
        private IPAddress myReceiverIP;

        public Packet(PacketType type, string message, IPAddress sender, IPAddress receiver)
        {
            myPacketType = type;
            myMessage = message;
            mySenderIP = sender;
            myReceiverIP = receiver;
        }

        public PacketType PacketType { get { return myPacketType; } set { myPacketType = value; } }
        public string Message { get { return myMessage; } set { myMessage = value; } }
        public IPAddress SenderIP { get { return mySenderIP; } set { mySenderIP = value; } }
        public IPAddress ReceiverIP { get { return myReceiverIP; } set { myReceiverIP = value; } }
    }
}
