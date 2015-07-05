using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using uChat_Client.Entities;

namespace uChat_Client.managers
{
    class ServerCommunicationManager
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        public string SendMessage(string message)
        {
            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            StreamWriter sw = new StreamWriter(nwStream);

            var newPacket = new Packet();
            newPacket.Message = message;
            newPacket.PacketType = PacketType.Login;
            newPacket.ReceiverIP = "0.0.0.0";
            newPacket.SenderIP = "0.0.0.0";

            string serializedPacket = SerializeToString(newPacket);

            sw.WriteLine(serializedPacket);
            sw.Flush();
            sw.Close();
            client.Close();

            return "";//Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }

        public string SerializeToString(Packet packet)
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

        public Packet DeserializeToObject(string data)
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
