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
        //we are giving the form to the manager, so that we can access it's properties within the thread.
        private Form myDialog;

        public ChatManager()
        {
        }

        public ChatManager(Form dialog)
        {
            myDialog = dialog;
        }

        /// <summary>
        /// Send login packet to the server.
        /// </summary>
        /// <param name="nickName">Nickname we are trying to login</param>
        /// <returns>True if sending was successfull</returns>
        public bool LogIn(string nickName)
        {
            ServerCommunicationManager manager = new ServerCommunicationManager();
            if (manager.SendMessage(nickName, PacketType.Login, nickName))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Send logout packet to the server.
        /// </summary>
        /// <param name="nickname">The nickname we are trying to logout</param>
        public void LogOut(string nickname)
        {
            new ServerCommunicationManager().SendMessage(string.Empty, PacketType.Logout, nickname);
        }

        /// <summary>
        /// Send a message packet to the server.
        /// </summary>
        /// <param name="messageToSend">Message we are trying to send.</param>
        /// <param name="receiverNickName">The nickname of the receiver of the message</param>
        /// <param name="nickname">Nickname of the sender (us)</param>
        /// <returns></returns>
        public bool SendMessage(string messageToSend, string receiverNickName, string nickname)
        {
            if (new ServerCommunicationManager().SendMessage(messageToSend + ";" + receiverNickName, PacketType.Message, nickname))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Send getallonlineusers packet.
        /// </summary>
        /// <param name="nickname">The nickname we want to exclude of the online users string</param>
        public void GetAllOnlineUsers(string nickname)
        {
            new ServerCommunicationManager().SendMessage(string.Empty, PacketType.GetOnlineUsers, nickname);
        }

        /// <summary>
        /// Starts infinite loop to receive packets from a server (Thread)
        /// </summary>
        public void startListening()
        {
            while (true)
            {
                ReceivePacket();
            }
        }

        /// <summary>
        /// Listens om the server port and processes the received packets.
        /// </summary>
        private void ReceivePacket()
        {
            var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8000);
            try
            {
                listener.Start();
            }
            catch (System.Exception)
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
                listener.Start();
            }

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
                    handleGetOnlineState(newPacket.SenderNickname);
                    break;
                case PacketType.Login:
                    handleLogin(newPacket);
                    break;
                case PacketType.Message:
                    handleMessage(newPacket);
                    break;
            }
            nwStream.Flush();
            client.Close();
            listener.Stop();
        }

        /// <summary>
        /// Handles the messages we get from the server. (Showing the message in the ui)
        /// </summary>
        /// <param name="newPacket"></param>
        private void handleMessage(Packet newPacket)
        {
            ((ChatDialog)myDialog).ShowMessage(newPacket.Message.Split(';')[0], newPacket.SenderNickname);
        }

        /// <summary>
        /// Processes the received online users string.
        /// </summary>
        /// <param name="newPacket">The received getonlineuserspacket</param>
        private void handleGetOnlineUsers(Packet newPacket)
        {
            List<User> users = new List<User>();
            string userStringToParse = newPacket.Message;
            string[] usersString = userStringToParse.Split('/');
            foreach (string userString in usersString)
            {
                if (!string.IsNullOrEmpty(userString.Split(';')[0]))
                {
                    string[] user = userString.Split(';');
                    users.Add(new User(IPAddress.Parse(user[1]), user[0]));
                }
            }
            foreach (User user in users)
	        {
                ((ChatDialog)myDialog).AddNewUserToUi(user.NickName);
	        }
        }

        /// <summary>
        /// if the login packet was successfull, the server sends it back. so we need to open the chat ui.
        /// </summary>
        /// <param name="packet"></param>
        private void handleLogin(Packet packet)
        {
            ChatDialog form = new ChatDialog(packet.SenderNickname);
            myDialog.Invoke((MethodInvoker)delegate()
            {
                form.Show();
            });

            //set login dialog to unvisible if successfully logged in
            myDialog.Visible = false;
            myDialog = form;
        }

        private void handleGetOnlineState(string nickname)
        {
            new ServerCommunicationManager().SendMessage(string.Empty, PacketType.GetOnlineState, nickname);
        }
    }
}