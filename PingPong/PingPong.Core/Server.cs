using System.Net;
using Core.Sockets.Abstractions;

namespace Core
{
    public class Server
    {
        public IPEndPoint EndPoint { get; }
        public IBindableListeningSocket ListeningSocket;

        public Server(IBindableListeningSocket listeningSocket, IPEndPoint iPEndPoint)
        {
            EndPoint = iPEndPoint;
            ListeningSocket = listeningSocket;
        }
    }
}
