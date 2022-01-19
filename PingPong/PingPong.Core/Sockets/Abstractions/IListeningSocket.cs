
namespace Core.Sockets.Abstractions
{
    public interface IListeningSocket
    {
        void Bind();
        void Listen();
        SocketBase Accept();
    }
}
