using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using uChatServer.Entities;
using uChatServer.Helpers;

namespace Server
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
            while (true)
            {
                startListening();
            }
        }

        private static System.Reflection.Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            return typeof(Packet).Assembly;
        }

        public static void startListening()
        {
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            ////---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            ////---convert the data received into a string---
            //string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            //Console.WriteLine("Received : " + dataReceived);

            ////---write back the text to the client---
            //Console.WriteLine("Sending back : " + dataReceived);
            //nwStream.Write(buffer, 0, bytesRead);

            //NetworkStream stream = client.GetStream();

            //IFormatter formatter = new BinaryFormatter();
            //formatter.Binder = new PreDeserializationBinder();

            //object obj = formatter.Deserialize(stream);


            client.Close();
            listener.Stop();
        }
    }
}
