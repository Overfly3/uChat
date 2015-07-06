using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using uChatServer.Entities;

namespace uChatServer
{
    public class Program
    {
        private const int PortNo = 5000;
        private const string ServerIp = "127.0.0.1";

        /// <summary>
        /// List to store connected users after loginevent was triggered.
        /// Dictionary<username, ipaddress>
        /// </summary>
        private Dictionary<string, string> _users;

        private static void Main(string[] args)
        {
            //instantiate our dictionary
            var program = new Program { _users = new Dictionary<string, string>() };

            //start infinite loop. after a packet (client) was handleed it will loop and wait for next connection
            while (true)
            {
                program.StartListening();
            }
        }

        private void StartListening()
        {
            var localAdd = IPAddress.Parse(ServerIp);
            //instantiate ur TcpListener with localhost and 5000 port
            var listener = new TcpListener(localAdd, PortNo);

            Console.WriteLine("Listening...");
            listener.Start();

            //waits until a client connects
            var client = listener.AcceptTcpClient();
            var nwStream = client.GetStream();
            var sr = new StreamReader(nwStream);

            //read the string a client sent to us
            var receivedString = sr.ReadToEnd();

            //deserialize the received string. the string is in xml format
            var newPacket = DeserializeToObject(receivedString);

            HandlePacket(newPacket);
            
            //important to flush the stream if there is any data to send. else it'll not be sent to the receiver
            nwStream.Flush();
            client.Close();
            listener.Stop();
        }
        /// <summary>
        /// Handles received packet the client sent.  
        /// </summary>
        /// <param name="newPacket">Deserialized Packet client sent to the server.</param>
        private void HandlePacket(Packet newPacket)
        {
            switch (newPacket.PacketType)
            {
                case PacketType.Message:
                    handleMessage(newPacket);
                    break;

                case PacketType.GetOnlineUsers:
                    SendOnlineUsers(newPacket);
                    break;

                case PacketType.Login:
                    HandleLogin(newPacket);
                    break;

                case PacketType.Logout:
                    HandleLogout(newPacket);
                    break;
            }
        }

        /// <summary>
        /// Splits the received packet with receiver name ; message.
        /// Looks into the connected user dictionary and sends the message to the corresponding user.
        /// </summary>
        /// <param name="newPacket">Deserialized Packet the client sent to the server.</param>
        private void handleMessage(Packet newPacket)
        {
            newPacket.ReceiverIP = getIpByNickname(newPacket.Message.Split(';')[1]);
            Send(newPacket, newPacket.Message);
            newPacket.ReceiverIP = newPacket.ReceiverIP;
            Send(newPacket, newPacket.Message);
        }

        /// <summary>
        /// Looks into the connected users Dictionary and returns the ip by nickname.
        /// </summary>
        /// <param name="nickname">Nickname in the dictionary; Key of the dictionary.</param>
        /// <returns></returns>
        private string getIpByNickname(string nickname)
        {
            return _users[nickname];
        }

        /// <summary>
        /// Removes the user which sent a logout packet from the connected user dictionary.
        /// </summary>
        /// <param name="newPacket">Deserialized Packet the client Sent to the server.</param>
        private void HandleLogout(Packet newPacket)
        {
            if (_users.ContainsKey(newPacket.SenderNickname))
            {
                _users.Remove(newPacket.SenderNickname);
            }
            Send(newPacket, "true");
        }

        /// <summary>
        /// Creates a packet with a generated user string from the connected user dictionary.
        /// </summary>
        /// <param name="newPacket">Deserialized packet the client sent to the Server.</param>
        private void SendOnlineUsers(Packet newPacket)
        {

            string onlineUsersString = getOnlineUsersList(newPacket.SenderNickname);
            newPacket.ReceiverIP = newPacket.SenderIP;
            Send(newPacket, onlineUsersString);
        }

        /// <summary>
        /// Checks if the user is already in the connected users dictionary. If not, the new user will be added.
        /// After adding the user the new connected user list will be sent to every connected user.
        /// </summary>
        /// <param name="newPacket">Deserialized Packet the client sent to the server.</param>
        private void HandleLogin(Packet newPacket)
        {
            string success = "false";

            if (!_users.ContainsKey(newPacket.SenderNickname))
            {
                _users.Add(newPacket.SenderNickname, newPacket.SenderIP);
                success = "true";
            }
            newPacket.ReceiverIP = newPacket.SenderIP;
            Send(newPacket, success);

            foreach (var user in _users)
            {
                if (user.Key != newPacket.SenderNickname)
                {
                    var onlineUsersPacket = new Packet
                    {
                        PacketType = PacketType.GetOnlineUsers,
                        ReceiverIP = user.Value
                    };
                    Send(onlineUsersPacket, getOnlineUsersList(user.Key));
                }
            }
        }

        /// <summary>
        /// Helper method to generate a string from the connected users dictionary.
        /// The string looks like: Username;IPaddress/Username;IPaddress/
        /// </summary>
        /// <param name="nickNameToRemove">The user requesting the connected users list to remove from the string.</param>
        /// <returns></returns>
        private string getOnlineUsersList(string nickNameToRemove)
        {
            return _users.Where(user => user.Key != nickNameToRemove).Aggregate<KeyValuePair<string, string>, string>(null, (current, user) => current + (user.Key + ";" + user.Value + "/"));
        }

        /// <summary>
        /// Sends a packet to the defined receiver ip in the packet.
        /// </summary>
        /// <param name="newPacket">Packet with the receiver informations</param>
        /// <param name="str">String which will be processed and appended to the message in the packet.</param>
        private void Send(Packet newPacket, string str)
        {
            try
            {
                var client = new TcpClient(newPacket.ReceiverIP, 8000);
                NetworkStream nwStream = client.GetStream();
                var sw = new StreamWriter(nwStream);
                if (!string.IsNullOrEmpty(str))
                {
                    newPacket.Message = str;
                }

                var serializedPacket = SerializeToString(newPacket);

                sw.WriteLine(serializedPacket);

                sw.Flush();
                sw.Close();
                client.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serializes a object with an xml serializer to a string.
        /// </summary>
        /// <param name="packet">Packet to serialize</param>
        /// <returns>XML string of the serialized packet.</returns>
        private string SerializeToString(Packet packet)
        {
            string serializedData;

            var serializer = new XmlSerializer(packet.GetType());

            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, packet);
                serializedData = sw.ToString();
            }
            return serializedData;
        }

        /// <summary>
        /// Deserializes a xml string to a packet.
        /// </summary>
        /// <param name="data">serialized XML string</param>
        /// <returns>Deserialized PAcket object</returns>
        private Packet DeserializeToObject(string data)
        {
            Packet deserializedPacket;

            var deserializer = new XmlSerializer(typeof(Packet));
            using (TextReader tr = new StringReader(data))
            {
                deserializedPacket = (Packet)deserializer.Deserialize(tr);
            }
            return deserializedPacket;
        }
    }
}