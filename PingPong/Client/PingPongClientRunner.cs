using Core;
using Core.Converters;
using Core.Input.Abstractions;
using Core.Output.Abstractions;
using System;

namespace PingPongClient
{
    public class PingPongClientRunner
    {
        private Client _client;
        private IInput _userInput;
        private IOutput _userOutput;
        private StringToByteArrayConverter _stringToByteArrayConverter;
        private ByteArrayToStringConverter _byteArrayToStringConverter;

        public PingPongClientRunner(Client client, IInput userInput, IOutput userOutput)
        {
            _client = client;
            _userInput = userInput;
            _userOutput = userOutput;
        }

        public void Run()
        {
            try
            {
                bool run = true;
                byte[] clientMessage;
                byte[] serverMessage;
                _client.Socket.Connect();

                while (_client.Socket.Connected() && run)
                {
                    _userOutput.Send(_stringToByteArrayConverter.Convert("Enter Message (Exit to stop): "));
                    clientMessage = _userInput.Receive();

                    if(_byteArrayToStringConverter.Convert(clientMessage) != "Exit")
                    {
                        run = false;
                    }

                    _client.Socket.Send(clientMessage);
                    serverMessage = _client.Socket.Receive();
                }
            }
            catch(Exception e)
            {
                
            }
            finally
            {
                _client.Socket.Close();
            }
        }
    }
}
