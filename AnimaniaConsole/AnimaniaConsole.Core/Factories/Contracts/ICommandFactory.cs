using AnimaniaConsole.Core.Commands.CommandContracts;

namespace AnimaniaConsole.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand Create(string cmdName);
    }
}