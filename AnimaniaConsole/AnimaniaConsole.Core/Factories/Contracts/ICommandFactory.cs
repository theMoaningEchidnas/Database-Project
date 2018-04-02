using AnimaniaConsole.Core.CommandContracts;

namespace AnimaniaConsole.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string cmdName);
    }
}