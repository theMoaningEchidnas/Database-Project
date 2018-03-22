using AnimaniaConsole.Core.Factories;

namespace AnimaniaConsole.Core.CommandContracts
{
    public interface ICommandParser
    {
        ICommandFactory CmdFactory { get; }

        ICommand ParseCommand(string commandLine);
    }
}