using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using uChat_Client.dialogs;
using uChat_Client.Entities;

namespace uChat_Client.managers
{
    public class ChatManager
    {
        private Form myDialog;
        private bool myThreadShouldStop;

        public ChatManager()
        {
            myThreadShouldStop = false;
        }

        public ChatManager(Form dialog)
        {
            myDialog = dialog;
            myThreadShouldStop = false;
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
            while (true && !myThreadShouldStop)
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

            switch (newPacket.PacketType)
            {
                case PacketType.GetOnlineUsers:
                    handleGetOnlineUsers(newPacket);
                    break;
                case PacketType.GetOnlineState:
                    handleGetOnlineState();
                    break;
                case PacketType.Login:
                    handleLogin(newPacket);
                    break;
                case PacketType.Message:
                    handleMessage(newPacket);
                    break;
            }
        }

        private void handleMessage(Packet newPacket)
        {
            ((ChatDialog)myDialog).ShowMessage(newPacket.Message, newPacket.SenderIP);
        }

        private void handleGetOnlineUsers(Packet newPacket)
        {
            List<User> users = new List<User>();
            string userStringToParse = newPacket.Message;
            string[] usersString = userStringToParse.Split('/');
            foreach (string userString in usersString)
            {
                string[] user = userString.Split(';');
                users.Add(new User(IPAddress.Parse(user[1]), user[0]));
            }
            foreach (User user in users)
	        {
                ((ChatDialog)myDialog).AddNewUserToUi(user.NickName);
	        }
        }

        private void handleLogin(Packet packet)
        {
            new ChatDialog(packet.Message).Show();

            //set login dialog to unvisible if successfully logged in
            myDialog.Visible = false;
            myThreadShouldStop = true;
        }

        private void handleGetOnlineState()
        {
            new ServerCommunicationManager().SendMessage(string.Empty, PacketType.GetOnlineState);
        }
    }
}