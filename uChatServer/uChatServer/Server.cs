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
    internal class Program
    {
        private const int PortNo = 5000;
        private const string ServerIp = "127.0.0.1";

        private Dictionary<string, TcpClient> _users;

        private static void Main(string[] args)
        {
            var program = new Program { _users = new Dictionary<string, TcpClient>() };

            while (true)
            {
                program.StartListening();
            }
        }

        private void StartListening()
        {
            var localAdd = IPAddress.Parse(ServerIp);
            var listener = new TcpListener(localAdd, PortNo);

            Console.WriteLine("Listening...");
            listener.Start();

            var client = listener.AcceptTcpClient();
            var nwStream = client.GetStream();
            var sr = new StreamReader(nwStream);

            var receivedString = sr.ReadToEnd();

            var newPacket = DeserializeToObject(receivedString);

            HandlePacket(newPacket, client);

            client.Close();
            listener.Stop();
        }

        private void HandlePacket(Packet newPacket, TcpClient client)
        {
            switch (newPacket.PacketType)
            {
                case PacketType.Message:
                    Send(newPacket, newPacket.Message, client);
                    break;

                case PacketType.GetOnlineUsers:
                    SendOnlineUsers(newPacket, client);
                    break;

                case PacketType.Login:
                    HandleLogin(newPacket, client);
                    break;

                case PacketType.Logout:
                    HandleLogout(newPacket, client);
                    break;
            }
        }

        private void HandleLogout(Packet newPacket, TcpClient client)
        {
            if (_users.ContainsKey(newPacket.SenderIP))
            {
                _users.Remove(newPacket.SenderIP);
            }
            Send(newPacket, "true", client);
        }

        private void SendOnlineUsers(Packet newPacket, TcpClient client)
        {

            string onlineUsersString = _users.Aggregate<KeyValuePair<string, TcpClient>, string>(null, (current, user) => current + (user.Key + ";" + ((IPEndPoint)user.Value.Client.RemoteEndPoint).ToString() + "/"));
            Send(newPacket, onlineUsersString, client);
        }

        private void HandleLogin(Packet newPacket, TcpClient client)
        {
            string success = "false";

            if (!_users.ContainsKey(newPacket.SenderIP))
            {
                _users.Add(newPacket.SenderIP, client);
                success = "true";
            }

            Send(newPacket, success, client);
        }

        private void Send(Packet newPacket, string str, TcpClient client)
        {
            try
            {
                var nwStream = client.GetStream();
                var sr = new StreamWriter(nwStream);

                var packet = new Packet
                {
                    Message = str,
                    PacketType = newPacket.PacketType,
                    SenderIP = newPacket.SenderIP,
                    ReceiverIP = newPacket.ReceiverIP
                };

                var serializedPacket = SerializeToString(packet);

                sr.WriteLine(serializedPacket);

                sr.Flush();
                sr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

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