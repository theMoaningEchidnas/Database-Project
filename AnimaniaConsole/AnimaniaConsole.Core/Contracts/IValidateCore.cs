using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Contracts
{
    public interface IValidateCore
    {
        int IntFromString(string commandParameter, string parameterName);

        decimal DecimalFromString(string commandParameter, string parameterName);

    }
}
