using System.Net;
using Core.Sockets.Abstractions;

namespace Core
{
    public class Server
    {
        public IPEndPoint EndPoint { get; }
        public IListeningSocket ListeningSocket;

        public Server(IListeningSocket listeningSocket, IPEndPoint iPEndPoint)
        {
            EndPoint = iPEndPoint;
            ListeningSocket = listeningSocket;
        }
    }
}
