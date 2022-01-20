﻿using Core;
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
        private IInput _input;
        private ByteArrayToStringConverter _byteArrayToStringConverter;

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

            }
            finally
            {
                _server.ListeningSocket.Close();
            }
        }

        private void HandleClient(SocketBase socket)
        {
            byte[] messsage = new byte[1];
            while(_byteArrayToStringConverter.Convert(messsage) != "Exit")
            {
                messsage = socket.Receive();
                socket.Send(messsage);
            }
        }
    }
}
