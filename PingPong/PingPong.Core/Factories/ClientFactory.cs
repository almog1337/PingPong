using Core.Sockets;
using System.Net;
using System.Net.Sockets;

namespace Core.Factories
{
    public class ClientFactory
    {
        public Client CreateNetClient(string ipEndPoint, SocketType socketType, ProtocolType protocolType)
        {
            IPEndPoint iPEndPoint;
            IPEndPoint.TryParse(ipEndPoint, out iPEndPoint);

            NetSocket netSocket = new NetSocket(socketType, protocolType, iPEndPoint);

            return new Client(iPEndPoint, netSocket);
        }
    }
}
