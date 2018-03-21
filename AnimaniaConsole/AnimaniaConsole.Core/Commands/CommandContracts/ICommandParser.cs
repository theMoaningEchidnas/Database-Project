using AnimaniaConsole.Core.Commands.CommandContracts;
using AnimaniaConsole.Core.Factories;

namespace AnimaniaConsole.Core.Commands.CommandContracts
{
    public interface ICommandParser
    {
        ICommandFactory CmdFactory { get; }

        ICommand ParseCommand(string commandLine);
    }
}