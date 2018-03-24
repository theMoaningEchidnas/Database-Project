using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Factories.Contracts;

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
