using Core.Output.Abstractions;
using System;
using System.Text;

namespace Core.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Send(byte[] data)
        {
            string dataString = Encoding.ASCII.GetString(data);
            Console.WriteLine(dataString);
        }
    }
}
