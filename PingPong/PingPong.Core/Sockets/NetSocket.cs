using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Core.Sockets
{
    public class NetSocket : SocketBase
    {
        private Socket _socket;

        public NetSocket(SocketType socketType, ProtocolType protocolType, IPEndPoint iPEndPoint)
        {
            _socket = new Socket(socketType, protocolType);
            _socket.Connect(iPEndPoint);
        }

        public override void Send(byte[] data)
        {
            _socket.Send(data);
        }

        public override byte[] Receive()
        {
            byte[] data = new byte[1024];
            _socket.Receive(data);
            return data;
        }
    }
}
