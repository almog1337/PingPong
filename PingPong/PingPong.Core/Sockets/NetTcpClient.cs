using System.Net;
using System.Net.Sockets;

namespace Core.Sockets
{
    public class NetTcpClient : SocketBase
    {
        private TcpClient _tcpClient;
        private IPEndPoint _ipEndPoint;
        private NetworkStream _networkStream;
        private int _receiveLenth;

        public int ReceiveLenth 
        { 
            get { return _receiveLenth; }
            set
            {
                if(value > 0 && value < 4096)
                {
                    _receiveLenth = value;
                }
                else
                {
                    _receiveLenth = 1024;
                }
            }
        }
        public NetTcpClient(IPEndPoint iPEndPoint, int receiveLenth = 1024)
        {
            _tcpClient = new TcpClient();
            _ipEndPoint = iPEndPoint;
            _receiveLenth = receiveLenth;
        }

        public override void Close()
        {
            _tcpClient.Close();
        }

        public override void Connect()
        {
            _tcpClient.Connect(_ipEndPoint);
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