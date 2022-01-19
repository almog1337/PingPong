using Core.Sockets;
using System.Net;

namespace Core
{
    public class Client
    {
        public IPEndPoint EndPoint { get; }
        public  SocketBase Socket;

        public Client(IPEndPoint endPoint, SocketBase socket)
        {
            EndPoint = endPoint;
            Socket = socket;
        }
    }
}
