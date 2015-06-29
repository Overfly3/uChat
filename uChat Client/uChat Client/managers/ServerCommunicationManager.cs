using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            Stream nwStream = client.GetStream();
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
            newPacket.ReceiverIP = "0.0.0.0";
            newPacket.SenderIP = "0.0.0.0";

            //IFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(nwStream, newPacket);
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, newPacket);
            byte[] bytesToSend = stream.ToArray();

            nwStream.WriteAsync(bytesToSend, 0, bytesToSend.Length);

            
            return "";//Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }
    }
}
