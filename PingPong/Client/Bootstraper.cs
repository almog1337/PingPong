using Core;
using Core.Sockets;
using System.Net;
using System.Net.Sockets;

namespace PingPongClient
{
    public class Bootstraper
    {
        public Client CreateClient(string[] args)
        {
            IPEndPoint iPEndPoint;
            IPEndPoint.TryParse(args[0], out iPEndPoint);

            NetSocket netSocket = new NetSocket(SocketType.Stream, ProtocolType.Tcp, iPEndPoint);

            return new Client(iPEndPoint, netSocket);
        }
    }
}
