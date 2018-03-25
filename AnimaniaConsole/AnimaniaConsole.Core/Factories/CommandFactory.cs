using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Factories.Contracts;
using Autofac;

namespace AnimaniaConsole.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        protected readonly IComponentContext context;
        public CommandFactory(IComponentContext context)
        {
            this.context = context;
        }
        public ICommand Create(string cmdName)
        {
            return this.context.ResolveNamed<ICommand>(cmdName);
        }
    }
}
