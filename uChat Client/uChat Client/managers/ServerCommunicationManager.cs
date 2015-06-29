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
            //byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);

            //---send the text---
            //Console.WriteLine("Sending : " + message);
            //nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            //byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            //int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            //Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            //Console.ReadLine();
            //client.Close();

            var newPacket = new Packet();
            newPacket.Message = message;
            newPacket.PacketType = PacketType.Login;
            newPacket.ReceiverIP = IPAddress.Parse("0.0.0.0");
            newPacket.SenderIP = IPAddress.Parse("0.0.0.0");

            var xmlSerializer = new XmlSerializer(typeof(Packet));

            using (var memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, newPacket);
            }

            var networkStream = client.GetStream();
            if (networkStream.CanWrite)
            {
                xmlSerializer.Serialize(networkStream, newPacket);
            }

            return "";//Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }
    }
}
