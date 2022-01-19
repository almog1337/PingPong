using Core.Sockets;
using System.Net;

namespace Core
{
    public class Client
    {
        public IPEndPoint _endPoint { get; }
        public  SocketBase _socket;

        public Client(IPEndPoint endPoint, SocketBase socket)
        {
            _endPoint = endPoint;
            _socket = socket;
        }
    }
}
