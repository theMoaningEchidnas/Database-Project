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
        private readonly IUserService userService;
        private readonly UserSessionModel session;


        public DeactivateUserCommand(IWriter consoleWriter, IReader consoleReader, IUserService userService, UserSessionModel session)
        {
            this.consoleWriter = consoleWriter;
            this.consoleReader = consoleReader;
            this.userService = userService;
            this.session = session;
            
        }


        public string Execute(IList<string> parameters)
        {

            this.userService.GetLoggedUserId(session);

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
                var userName = session.UserName;
                userService.DeactivateUser(session.Id);
                userService.LogOutUser(session);
                return $"User {userName} was successfully deactivated!";
            }
            else
            {
                return $"User {session.UserName} remains ACTIVE!";
            }




        }
    }
}
