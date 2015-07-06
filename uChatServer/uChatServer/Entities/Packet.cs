using System;

namespace uChatServer.Entities
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
    /// <summary>
    /// Packet body to be sent. has to be the same on the client side, so that it can be serialized and deserialized.
    /// </summary>
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