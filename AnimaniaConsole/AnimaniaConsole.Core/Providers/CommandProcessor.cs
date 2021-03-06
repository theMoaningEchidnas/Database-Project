﻿using AnimaniaConsole.Core.CommandContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimaniaConsole.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        public ICollection<ICommand> Commands { get; set; }

        public CommandProcessor()
        {
            this.Commands = new List<ICommand>();
        }

        public string ProcessSingleCommand(ICommand command, string commandParameters)
        {
            var lineParameters = commandParameters.Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var result = command.Execute(lineParameters);
            var normalizedOutput = this.NormalizeOutput(result);
            return normalizedOutput;
        }

        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}
