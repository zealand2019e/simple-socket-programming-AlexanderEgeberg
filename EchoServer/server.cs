﻿using System;
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
                DoClient(socket);
            }
        }

        public static void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            int wordcount = 0;
            Console.WriteLine("server started");
            while (true)
            {

                string userMessage = reader.ReadLine();
                writer.WriteLine($"{userMessage}");
                Console.WriteLine($"user: {userMessage}");

                userMessage.ToString();
                string[] wordsArrayStrings = userMessage.Split(" ");
                wordcount = wordcount + wordsArrayStrings.Length;

                Console.WriteLine($"Current word count: {wordcount}");

            }
            Console.WriteLine("Server disconnected...");
        }
    }
}
