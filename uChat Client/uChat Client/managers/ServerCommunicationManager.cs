using System;
using System.IO;
using System.Net.Sockets;
using System.Xml.Serialization;
using uChat_Client.Entities;

namespace uChat_Client.managers
{
    internal class ServerCommunicationManager
    {
        private const int PORT_NO = 5000;
        private const string SERVER_IP = "127.0.0.1";

        public bool SendMessage(string message, PacketType type)
        {
            try
            {
                //---create a TCPClient object at the IP and port no.---
                TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                NetworkStream nwStream = client.GetStream();
                StreamWriter sw = new StreamWriter(nwStream);

                var newPacket = new Packet();
                newPacket.Message = message;
                newPacket.PacketType = type;
                newPacket.ReceiverIP = "0.0.0.0";
                newPacket.SenderIP = "0.0.0.0";

                string serializedPacket = serializeToString(newPacket);

                sw.WriteLine(serializedPacket);
                sw.Flush();
                sw.Close();
                client.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string serializeToString(Packet packet)
        {
            string serializedData = string.Empty;

            XmlSerializer serializer = new XmlSerializer(packet.GetType());

            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, packet);
                serializedData = sw.ToString();
            }
            return serializedData;
        }

        public Packet deserializeToObject(string data)
        {
            Packet deserializedPacket;

            XmlSerializer deserializer = new XmlSerializer(typeof(Packet));
            using (TextReader tr = new StringReader(data))
            {
                deserializedPacket = (Packet)deserializer.Deserialize(tr);
            }
            return deserializedPacket;
        }
    }
}