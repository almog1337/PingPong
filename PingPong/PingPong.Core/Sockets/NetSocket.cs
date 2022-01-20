using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Core.Sockets
{
    public class NetSocket : SocketBase
    {
        private Socket _socket;
        private IPEndPoint _iPEndPoint;

        public NetSocket(SocketType socketType, ProtocolType protocolType, IPEndPoint iPEndPoint)
        {
            _socket = new Socket(socketType, protocolType);
            _iPEndPoint = iPEndPoint;
        }

        public NetSocket(Socket socket)
        {
            _socket = socket;
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

        public override void Connect()
        {
            _socket.Connect(_iPEndPoint);
        }

        public override void Close()
        {
            _socket.Close();
        }

        public override bool Connected()
        {
            return _socket.Connected;
        }
    }
}
