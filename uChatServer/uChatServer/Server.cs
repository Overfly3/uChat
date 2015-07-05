﻿using System;
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

        private Dictionary<string, string> _users;

        private static void Main(string[] args)
        {
            var program = new Program { _users = new Dictionary<string, string>() };

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

            HandlePacket(newPacket);

            nwStream.Flush();
            client.Close();
            listener.Stop();
        }

        private void HandlePacket(Packet newPacket)
        {
            switch (newPacket.PacketType)
            {
                case PacketType.Message:
                    Send(newPacket, newPacket.Message);
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

        private void HandleLogout(Packet newPacket)
        {
            if (_users.ContainsKey(newPacket.SenderNickname))
            {
                _users.Remove(newPacket.SenderNickname);
            }
            Send(newPacket, "true");
        }

        private void SendOnlineUsers(Packet newPacket)
        {

            string onlineUsersString = _users.Aggregate<KeyValuePair<string, string>, string>(null, (current, user) => current + (user.Key + ";" + newPacket.SenderIP + "/"));
            Send(newPacket, onlineUsersString);
        }

        private void HandleLogin(Packet newPacket)
        {
            string success = "false";

            if (!_users.ContainsKey(newPacket.SenderNickname))
            {
                _users.Add(newPacket.SenderNickname, newPacket.SenderIP);
                success = "true";
            }

            Send(newPacket, success);
        }

        private void Send(Packet newPacket, string str)
        {
            try
            {
                var client = new TcpClient(newPacket.SenderIP, 8000);
                NetworkStream nwStream = client.GetStream();
                var sw = new StreamWriter(nwStream);

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