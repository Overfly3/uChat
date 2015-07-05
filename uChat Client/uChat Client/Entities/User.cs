using System.Net;

namespace uChat_Client.Entities
{
    public class User
    {
        public User(IPAddress address, string nickName)
        {
            IpAddress = address;
            NickName = nickName;
        }

        public string NickName { get; set; }

        public IPAddress IpAddress { get; set; }
    }
}