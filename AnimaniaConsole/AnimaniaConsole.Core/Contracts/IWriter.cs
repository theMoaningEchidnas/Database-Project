using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Contracts
{
    public interface IWriter
    {
        void Write(string str);

        void WriteLine(string str);

        void NewLine();
    }
}
