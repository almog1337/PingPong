using Core.Sockets.Abstractions;
using System.Net.Sockets;

namespace Core.Sockets
{
    public class NetTcpListener : IListeningSocket
    {
        private TcpListener _tcpListener;
        public SocketBase Accept()
        {
            var tcpClient = _tcpListener.AcceptTcpClient();
            return new NetTcpClient(tcpClient);
        }

        public void Close()
        {
            _tcpListener.Stop();
        }

        public void Listen()
        {
            _tcpListener.Start();
        }
    }
}
