using System.Collections.Generic;

namespace AnimaniaConsole.Core.CommandContracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
