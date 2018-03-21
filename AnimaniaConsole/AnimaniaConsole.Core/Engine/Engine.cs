using AnimaniaConsole.Core.Commands.CommandContracts;
using AnimaniaConsole.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimaniaConsole.Core.Engine
{
    public class Engine:IEngine
    {
        private const string TerminationCommand = "exit";

        private IReader reader;
        private ICommandParser parser;
        private ICommandProcessor processor;
        private IWriter writer;

        public Engine(IReader reader,
            ICommandProcessor processor,
            ICommandParser parser,
            IWriter writer
 )
        {
            this.reader = reader;
            this.processor = processor;
            this.parser = parser;
            this.writer = writer;
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

        //private List<string> StringifyModelProperties(Object obj)
        //{
        //    var props = obj.GetType().GetProperties();
        //    foreach (var item in collection)
        //    {

        //    }
        //}
    }
}

