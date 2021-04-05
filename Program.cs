using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPServerBeer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("server starting listener!");

            TcpListener socket = BeerListener.Startlistener();

            while (true)
            {
                Task.Run((() => BeerListener.ReadWriteStream(BeerListener.GetTcpClient(socket))));
            }
        }
    }
}
