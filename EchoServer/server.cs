using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EchoServer
{
    class server
    {
        public static void StartUp()
        {
            int port = 7777;

            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, port);
            serverSocket.Start();

            TcpClient socket = serverSocket.AcceptTcpClient();

            using (socket)
            {

                NetworkStream ns = socket.GetStream();
                StreamReader reader = new StreamReader(ns);
                StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

                while (true)
                {
                    string serverMessage = Console.ReadLine();
                    writer.WriteLine($"server: {serverMessage}");
                    string userMessage = reader.ReadLine();
                    Console.WriteLine($"user: {userMessage}");
                }
                Console.WriteLine("Server disconnected...");
            }
        }

    }
}
