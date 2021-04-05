using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using TCPServerBeer.Model;

namespace TCPServerBeer
{
    public static class BeerListener
    {
        private static int clientnr = 0;

        public static TcpListener Startlistener()
        {
            TcpListener serverrSocket = new TcpListener(IPAddress.Loopback, 4646);
            serverrSocket.Start();
            Console.WriteLine("Server has started wating for client connection");
            return serverrSocket;
        }

        public static TcpClient GetTcpClient(TcpListener socket)
        {
            TcpClient clientConnection = socket.AcceptTcpClient();
            clientnr++;
            Console.WriteLine("Client " + clientnr + " connected");
            return clientConnection;
        }

        public static void ReadWriteStream(TcpClient client)
        {
            try
            {
                Stream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string message = sr.ReadLine();
                string answar = "";
                
                while (message != " " && message != "stop")
                {
                    Console.WriteLine("client: " + message);
                    switch (message)
                    {
                        case "GetAll":
                            Console.WriteLine(JsonConvert.SerializeObject(Beers.BeerList));
                            sw.WriteLine(JsonConvert.SerializeObject(Beers.BeerList));
                            break;
                        case "GetByID":
                            int id = Int32.Parse(sr.ReadLine());
                            answar = Beers.GetById(id).ToString();
                            Console.WriteLine(answar);
                            sw.WriteLine(answar);
                            break;
                        case "Save":
                            string JsonString = sr.ReadLine();
                            Beer beer = JsonConvert.DeserializeObject<Beer>(JsonString);
                            Beers.Addbeer(beer);
                            break;
                        default:
                            answar = "bad request";
                            Console.WriteLine(answar);
                            sw.WriteLine(answar);
                            break;

                    }
                    message = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
