
namespace Core.Sockets.Abstractions
{
    public interface IListeningSocket : IBindable
    {
        void Listen();
        SocketBase Accept();
        void Close();
    }
}
