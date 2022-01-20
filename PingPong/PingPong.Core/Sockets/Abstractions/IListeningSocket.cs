
namespace Core.Sockets.Abstractions
{
    public interface IListeningSocket
    {
        void Listen();
        SocketBase Accept();
        void Close();
    }
}
