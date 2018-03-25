using AnimaniaConsole.Core.Contracts;
using System;

namespace AnimaniaConsole.Core.Wrappers
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
