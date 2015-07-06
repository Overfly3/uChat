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

        public bool SendMessage(string message, PacketType type, string nickname)
        {
            try
            {
                //---create a TCPClient object at the IP and port no.---
                TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                NetworkStream nwStream = client.GetStream();
                StreamWriter sw = new StreamWriter(nwStream);

                //create a basic packet with message type to send
                var newPacket = new Packet
                {
                    Message = message,
                    PacketType = type,
                    ReceiverIP = "0.0.0.0",
                    SenderNickname = nickname,
                    SenderIP = "127.0.0.1"
                };

                //serialize the pacet object to a xml string
                string serializedPacket = serializeToString(newPacket);

                //write the serialized xml string into the stream
                //flush and close are necessary to be sure that the stream will be sent.
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

        /// <summary>
        /// Helper method to serialize an object to an xml string.
        /// </summary>
        /// <param name="packet">Packet object to serialize</param>
        /// <returns>Serialized xml string</returns>
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

        /// <summary>
        /// Helper method to deserialized an xml string to an object.
        /// </summary>
        /// <param name="data">Serialized xml string</param>
        /// <returns>Deserialized PAcket object</returns>
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