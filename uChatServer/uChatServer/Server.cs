using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using uChatServer.Entities;

namespace Server
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {

            while (true)
            {
                startListening();
            }
        }

        public static void startListening()
        {
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream nwStream = client.GetStream();
            StreamReader sr = new StreamReader(nwStream);

            Packet newPacket;
            string receivedString = sr.ReadToEnd();

            newPacket = DeserializeToObject(receivedString);

            client.Close();
            listener.Stop();
        }
        public static string SerializeToString(Packet packet)
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

        public static Packet DeserializeToObject(string data)
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
