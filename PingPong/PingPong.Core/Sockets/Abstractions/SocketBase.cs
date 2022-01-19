using Core.Input.Abstractions;
using Core.Output.Abstractions;
using System;
using System.Threading.Tasks;

namespace Core.Sockets
{
    public abstract class SocketBase : IInput, IOutput
    {
        public abstract void Send(byte[] data);
        public abstract byte[] Receive();
    }
}
