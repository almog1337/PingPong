using Core.Input;
using Core.Output;
using Core.Sockets;
using System;
using System.Net;
using System.Net.Sockets;

namespace PingPongClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint iPEndPoint;
                var IpParsed = IPEndPoint.TryParse("127.0.0.1:1337", out iPEndPoint);

                if (!IpParsed)
                {
                    System.Console.WriteLine("Given endpoint couldn't be parsed");
                    return;
                }

                NetSocket netSocket = new NetSocket(SocketType.Stream, ProtocolType.Tcp, iPEndPoint);

                var consoleInput = new ConsoleInput();
                var consoleOutput = new ConsoleOutput();

                var pingPongRunner = new PingPongClientRunner(netSocket, consoleInput, consoleOutput);
                pingPongRunner.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
