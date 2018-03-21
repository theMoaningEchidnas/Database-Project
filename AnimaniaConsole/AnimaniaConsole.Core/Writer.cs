using AnimaniaConsole.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
