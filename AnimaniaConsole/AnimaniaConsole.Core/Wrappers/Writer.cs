using AnimaniaConsole.Core.Contracts;
using System;

namespace AnimaniaConsole.Core.Wrappers
{
    public class Writer : IWriter
    {
        public void NewLine()
        {
            Console.WriteLine();
        }

        public void Write(string str)
        {
            Console.Write(str);
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
