using Core;
using Core.Converters;
using Core.Output;
using Core.Sockets;
using System;
using System.Net;
using System.Net.Sockets;

namespace PingPongServer
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

                NetListeningSocket socket = new NetListeningSocket(SocketType.Stream, ProtocolType.Tcp, iPEndPoint);
                var server = new Server(socket, iPEndPoint);

                var converter = new ByteArrayToStringConverter();
                var pingPongServerRunner = new PingPongServerRunner(server, converter);

                pingPongServerRunner.Run();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }
    }
}
