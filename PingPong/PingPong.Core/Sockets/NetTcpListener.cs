using Core.Sockets.Abstractions;
using System.Net.Sockets;

namespace Core.Sockets
{
    public class NetTcpListener : IListeningSocket
    {
        private TcpListener _tcpListener;
        public SocketBase Accept()
        {
            throw new System.NotImplementedException();
        }

        public void Bind()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Listen()
        {
            throw new System.NotImplementedException();
        }
    }
}
