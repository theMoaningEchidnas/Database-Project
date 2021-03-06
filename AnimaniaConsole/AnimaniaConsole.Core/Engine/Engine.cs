﻿using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Services.Contracts;
using System;

namespace AnimaniaConsole.Core.Engine
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";

        private IReader reader;
        private ICommandParser parser;
        private ICommandProcessor processor;
        private IWriter writer;
        private readonly IBreedTypeServices breedService;

        public Engine(IReader reader,
            ICommandProcessor processor,
            ICommandParser parser,
            IWriter writer,
            IBreedTypeServices breedService
            )
        {
            this.reader = reader;
            this.processor = processor;
            this.parser = parser;
            this.writer = writer;
            this.breedService = breedService;
        }

        string commandAsString = null;

        public void Run()
        {
            this.writer.WriteLine("****************************************************************");
            this.writer.WriteLine("********        Welcome to Animanima Console App        ********");
            this.writer.WriteLine("****************************************************************");
            this.writer.WriteLine("");
            this.writer.WriteLine("Please, type 'Help' to show all available commands and their parameters");
            this.writer.WriteLine("");
            this.writer.WriteLine("Most of the commands require LogIn, so please take a minute to Register.");
            this.writer.WriteLine("");

            //breedService.LoadBreedsFromJSON("breedsjson.txt", "Dog");
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

    }
}

