using System.Net;
using System.Net.Sockets;

namespace Core.Sockets
{
    public class NetTcpClient : SocketBase
    {
        private TcpClient _tcpClient;
        private IPEndPoint _iPEndPoint;
        private NetworkStream _networkStream;

        public int ReceiveLenth 
        { 
            get { return ReceiveLenth; }
            set
            {
                ReceiveLenth = value > 0 && value < 4096 ? value : ReceiveLenth;
            }
        }
        public NetTcpClient(IPEndPoint iPEndPoint)
        {
            _tcpClient = new TcpClient();
            _iPEndPoint = iPEndPoint;
        }

        public override void Close()
        {
            _tcpClient.Close();
        }

        public override void Connect()
        {
            _tcpClient.Connect(_iPEndPoint);
            _networkStream = _tcpClient.GetStream();
        }

        public override bool Connected()
        {
            return _tcpClient.Connected;
        }

        public override byte[] Receive()
        {
            byte[] data = new byte[ReceiveLenth];
            _networkStream.Read(data, 0, ReceiveLenth);
            return data;
        }

        public override void Send(byte[] data)
        {
            var networkStream = _tcpClient.GetStream();
            _networkStream.Write(data, 0, data.Length);
        }
    }
}