using Core.Input.Abstractions;
using Core.Output.Abstractions;

namespace Core.Sockets
{
    public abstract class SocketBase : IInput, IOutput
    {
        public abstract void Connect();
        public abstract void Send(byte[] data);
        public abstract byte[] Receive();
        public abstract void Close();
    }
}
