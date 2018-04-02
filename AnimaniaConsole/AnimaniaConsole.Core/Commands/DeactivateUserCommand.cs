using System;
using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    public class DeactivateUserCommand : ICommand
    {
        private readonly IWriter consoleWriter;
        private readonly IReader consoleReader;
        private readonly IUserServices userService;


        public DeactivateUserCommand(IWriter consoleWriter, IReader consoleReader, IUserServices userService)
        {
            this.consoleWriter = consoleWriter ?? throw new ArgumentNullException();
            this.consoleReader = consoleReader ?? throw new ArgumentNullException();
            this.userService = userService ?? throw new ArgumentNullException();           
        }


        public string Execute(IList<string> parameters)
        {

            this.userService.GetLoggedUserId();

            consoleWriter.WriteLine("Are you sure? Please confirm: 'Yes' or 'No' ");
            var response = consoleReader.ReadLine();
            while (response != "Yes" && response != "No")
            {
                consoleWriter.WriteLine("Please, write either Yes or No");
                response = consoleReader.ReadLine();
            }

            if (response == "Yes")
            {
                //Deactivate
                var userName = userService.GetLoggedUserName();
                userService.DeactivateUser(userService.GetLoggedUserId());
                userService.LogOutUser();
                return $"User {userName} was successfully deactivated!";
            }
            else
            {
                return $"User {userService.GetLoggedUserName()} remains ACTIVE!";
            }




        }
    }
}
