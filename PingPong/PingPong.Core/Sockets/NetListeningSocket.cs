using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Core.Sockets.Abstractions;

namespace Core.Sockets
{
    public class NetListeningSocket : ListeningSocketBase
    {
        private Socket _socket;
        private IPEndPoint _bindEndPoint;

        public NetListeningSocket(SocketType socketType, ProtocolType protocolType, IPEndPoint iPEndPoint)
        {
            _socket = new Socket(socketType, protocolType);
            
        }

        public void Bind()
        {
            _socket.Bind(_bindEndPoint);
        }

        public void Listen()
        {
            _socket.Listen();
        }

        public SocketBase Accept()
        {
            var sock = _socket.Accept();
            return new NetSocket(sock);
        }
    }
}
