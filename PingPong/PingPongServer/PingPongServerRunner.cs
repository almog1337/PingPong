using Core;
using Core.Converters;
using Core.Input.Abstractions;
using Core.Sockets;
using System;
using System.Threading.Tasks;

namespace PingPongServer
{
    public class PingPongServerRunner
    {
        private Server _server;
        private ByteArrayToStringConverter _byteArrayToStringConverter;

        public PingPongServerRunner(Server server, ByteArrayToStringConverter byteArrayToStringConverter)
        {
            _server = server;
            _byteArrayToStringConverter = byteArrayToStringConverter;
        }

        public void Run()
        {
            try
            {
                _server.ListeningSocket.Bind();
                _server.ListeningSocket.Listen();
                while (true)
                {
                    var socket = _server.ListeningSocket.Accept();
                    Task.Run(() => HandleClient(socket));
                }
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                _server.ListeningSocket.Close();
            }
        }

        private void HandleClient(SocketBase socket)
        {
            try
            {
                byte[] messsage = new byte[1];
                while (_byteArrayToStringConverter.Convert(messsage) != "Exit")
                {
                    messsage = socket.Receive();
                    socket.Send(messsage);
                }
            }
            catch(Exception e)
            {
                
            }
            finally
            {
                socket.Close();
            }
        }
    }
}
