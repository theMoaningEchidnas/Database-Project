using System.Collections.Generic;

namespace AnimaniaConsole.Core.CommandContracts
{
    public interface ICommandProcessor
    {
        ICollection<ICommand> Commands { get; set; }

        string ProcessSingleCommand(ICommand command, string commandParameters);
    }
}