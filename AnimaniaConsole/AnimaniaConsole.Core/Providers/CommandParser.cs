using System;
using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Factories.Contracts;

namespace AnimaniaConsole.Core.Providers
{

    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory cmdFactory;

        public CommandParser(ICommandFactory cmdFactory)
        {
            this.cmdFactory = cmdFactory;
        }

        public ICommandFactory CmdFactory => cmdFactory;

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];

            var command = this.CmdFactory.Create(commandName);

            // command do something

            return command;
        }
    }
}