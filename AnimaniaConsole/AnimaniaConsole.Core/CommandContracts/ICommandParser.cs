using AnimaniaConsole.Core.Factories;
using AnimaniaConsole.Core.Factories.Contracts;

namespace AnimaniaConsole.Core.CommandContracts
{
    public interface ICommandParser
    {
        ICommandFactory CmdFactory { get; }

        ICommand ParseCommand(string commandLine);
    }
}