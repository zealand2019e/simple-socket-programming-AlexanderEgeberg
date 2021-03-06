﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EchoClient
{
    class Client
    {
        public static void Start()
        {
            int port = 7777;

            TcpClient client = new TcpClient("localhost", port);

            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            Console.WriteLine("Client connected to server");
            while (true)
            {
                string clientMessage = Console.ReadLine();
                writer.WriteLine($"{clientMessage}");
                string serverMessage = reader.ReadLine();
                Console.WriteLine($"server: {serverMessage}");
            }   
        }
    }
}
