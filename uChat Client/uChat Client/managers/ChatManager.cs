using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uChat_Client.Entities;

namespace uChat_Client.managers
{
    class ChatManager
    {
        public bool LogIn(string nickName)
        {
            ServerCommunicationManager manager = new ServerCommunicationManager();
            if (manager.SendMessage(nickName, PacketType.Login) == "true")
            {
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            new ServerCommunicationManager().SendMessage(string.Empty, PacketType.Logout);
        }

        public bool SendMessage(string messageToSend, string receiverNickName)
        {
            if (new ServerCommunicationManager().SendMessage(messageToSend + ";" + receiverNickName, PacketType.Message) == "true")
            {
                return true;
            }
            return false;
        }

        public List<User> GetAllOnlineUsers()
        {
            List<User> users = new List<User>();
            string userStringToParse = new ServerCommunicationManager().SendMessage(string.Empty, PacketType.GetOnlineUsers);
            string[] usersString = userStringToParse.Split('/');
            foreach (string userString in usersString)
            {
                string[] user = userString.Split(';');
                users.Add(new User(IPAddress.Parse(user[1]), user[0]));
            }
            return users;
        }
    }
}
