using Core;
using Core.Converters;
using Core.Input.Abstractions;
using Core.Output.Abstractions;
using Core.Sockets;
using System;

namespace PingPongClient
{
    public class PingPongClientRunner
    {
        private SocketBase _socket;
        private IInput _userInput;
        private IOutput _userOutput;
        private StringToByteArrayConverter _stringToByteArrayConverter;
        private ByteArrayToStringConverter _byteArrayToStringConverter;

        public PingPongClientRunner(SocketBase socket, IInput userInput, IOutput userOutput)
        {
            _socket = socket;
            _userInput = userInput;
            _userOutput = userOutput;
            _stringToByteArrayConverter = new StringToByteArrayConverter();
            _byteArrayToStringConverter = new ByteArrayToStringConverter();
        }

        public void Run()
        {
            try
            {
                bool run = true;
                byte[] clientMessage;
                byte[] serverMessage;
                _socket.Connect();

                while (_socket.Connected() && run)
                {
                    _userOutput.Send(_stringToByteArrayConverter.Convert("Enter Message (Exit to stop): "));
                    clientMessage = _userInput.Receive();

                    if(_byteArrayToStringConverter.Convert(clientMessage) == "Exit")
                    {
                        run = false;
                    }

                    _socket.Send(clientMessage);
                    serverMessage = _socket.Receive();

                    _userOutput.Send(_stringToByteArrayConverter.Convert("Server message: "));
                    _userOutput.Send(serverMessage);
                }
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                _socket.Close();
            }
        }
    }
}
