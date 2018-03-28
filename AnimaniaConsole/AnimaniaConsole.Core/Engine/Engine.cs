using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.DTO.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AnimaniaConsole.Core.Engine
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";

        private IReader reader;
        private ICommandParser parser;
        private ICommandProcessor processor;
        private IWriter writer;
        private UserSessionModel session;

        public Engine(IReader reader,
            ICommandProcessor processor,
            ICommandParser parser,
            IWriter writer,
            UserSessionModel session

             )
        {
            this.reader = reader;
            this.processor = processor;
            this.parser = parser;
            this.writer = writer;
            this.session = session;
        }

        string commandAsString = null;

        public void Run()

        {
            while ((commandAsString = this.reader.ReadLine()) != TerminationCommand)
            {
                try
                {
                    var command = this.parser.ParseCommand(commandAsString);
                    
                    if (command != null)
                    {
                        var commandResult = this.processor.ProcessSingleCommand(command, commandAsString);
                        this.writer.WriteLine(commandResult);
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private List<string> StringifyModelProperties(Object obj)
        {
            List<string> propertyNames = new List<string>();
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                propertyNames.Add(prop.Name);
            }

            return propertyNames;
        }
    }
}

