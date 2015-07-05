using System.IO;
using System.Net;
using System.Net.Sockets;
using uChat_Client.dialogs;
using uChat_Client.Entities;

namespace uChat_Client.managers
{
    internal class ChatManager
    {
        private ChatDialog myDialog;

        public ChatManager()
        {
        }

        public ChatManager(ChatDialog dialog)
        {
            myDialog = dialog;
        }

        public bool LogIn(string nickName)
        {
            ServerCommunicationManager manager = new ServerCommunicationManager();
            if (manager.SendMessage(nickName, PacketType.Login))
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
            if (new ServerCommunicationManager().SendMessage(messageToSend + ";" + receiverNickName, PacketType.Message))
            {
                return true;
            }
            return false;
        }

        public void GetAllOnlineUsers()
        {
            new ServerCommunicationManager().SendMessage(string.Empty, PacketType.GetOnlineUsers);
        }

        public void startListening()
        {
            while (true)
            {
                ReceivePacket();
            }
        }

        private void ReceivePacket()
        {
            var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8000);

            listener.Start();

            var client = listener.AcceptTcpClient();
            var nwStream = client.GetStream();
            var sr = new StreamReader(nwStream);

            var receivedString = sr.ReadToEnd();

            var newPacket = new ServerCommunicationManager().deserializeToObject(receivedString);

            //TextBox fuu = (TextBox)myDialog.Controls.Find("", true)[0];
            //fuu.Text = "OP";

            switch (newPacket.PacketType)
            {
                case PacketType.GetOnlineUsers:

                    break;
            }
        }
    }
}