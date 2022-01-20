using System.Net;
using System.Net.Sockets;

namespace Core.Sockets
{
    public class NetTcpClient : SocketBase
    {
        private TcpClient _tcpClient;
        private IPEndPoint _ipEndPoint;
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

        public NetTcpClient(TcpClient tcpClient, int receiveLenth = 1024)
        {
            _tcpClient = tcpClient;
            _receiveLenth = receiveLenth;
            _ipEndPoint = (IPEndPoint)_tcpClient.Client.RemoteEndPoint;
        }

        public override void Close()
        {
            _tcpClient.Close();
        }

        public override void Connect()
        {
            _tcpClient.Connect(_ipEndPoint);
        }

        public override bool Connected()
        {
            return _tcpClient.Connected;
        }

        public override byte[] Receive()
        {
            byte[] data = new byte[ReceiveLenth];
            _tcpClient.GetStream().Read(data, 0, ReceiveLenth);
            return data;
        }

        public override void Send(byte[] data)
        {
            _tcpClient.GetStream().Write(data, 0, data.Length);
        }
    }
}