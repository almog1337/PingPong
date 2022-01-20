using Core;
using System;

namespace PingPongServer
{
    public class PingPongServerRunner
    {
        private Server _server;
        
        public void Run()
        {
            try
            {
                _server.ListeningSocket.Bind();
                _server.ListeningSocket.Listen();

                //TODO:: task that accept clients
                //TODO:: readline 
                //TODO:: stop running
                _server.ListeningSocket.
                
            }
            catch(Exception e)
            {

            }
            finally
            {

            }
        }
    }
}
