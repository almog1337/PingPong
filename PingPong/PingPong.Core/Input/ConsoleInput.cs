using Core.Input.Abstractions;
using System;
using System.Text;

namespace Core.Input
{
    public class ConsoleInput : IInput
    {
        public byte[] Receive()
        {
            string input = Console.ReadLine();
            return Encoding.ASCII.GetBytes(input);
        }
    }
}
