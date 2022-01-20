using Core;
using Core.Sockets;
using System.Net;
using System.Net.Sockets;

namespace PingPongClient
{
    public class ClientFactory
    {
        public Client CreateClient(string ipEndPoint)
        {
            IPEndPoint iPEndPoint;
            IPEndPoint.TryParse(ipEndPoint, out iPEndPoint);

            NetSocket netSocket = new NetSocket(SocketType.Stream, ProtocolType.Tcp, iPEndPoint);

            return new Client(iPEndPoint, netSocket);
        }
    }
}
