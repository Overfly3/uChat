using System;

namespace uChat_Client.Entities
{
    [Serializable]
    public enum PacketType
    {
        Login,
        GetOnlineUsers,
        Logout,
        Message,
        GetOnlineState
    }

    [Serializable]
    public class Packet
    {
        public string SenderIP { get; set; }

        public PacketType PacketType { get; set; }

        public string Message { get; set; }

        public string SenderNickname { get; set; }

        public string ReceiverIP { get; set; }
    }
}