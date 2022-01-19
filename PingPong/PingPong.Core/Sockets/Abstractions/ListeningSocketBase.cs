
namespace Core.Sockets.Abstractions
{
    public interface ListeningSocketBase
    {
        void Bind();
        void Listen();
        SocketBase Accept();
    }
}
