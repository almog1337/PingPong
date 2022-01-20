using Core.Sockets;
using System.Net;

namespace Core.Clients.Abstractions
{
    public class ClientBase
    {
        public IPEndPoint EndPoint { get; }
        public SocketBase Socket;

        protected ClientBase(IPEndPoint endPoint, SocketBase socket)
        {
            EndPoint = endPoint;
            Socket = socket;
        }
    }
}
