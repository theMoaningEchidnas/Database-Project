using System.Collections.Generic;
using AnimaniaConsole.Core.Commands.CommandContracts;

namespace AnimaniaConsole.Core.Commands.CommandContracts
{
    public interface ICommandProcessor
    {
        ICollection<ICommand> Commands { get; set; }

        string ProcessSingleCommand(ICommand command, string commandParameters);
    }
}