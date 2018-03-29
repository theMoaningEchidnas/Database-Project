using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;

namespace AnimaniaConsole.Core.Commands
{
    //LogInUser;Buser;Bpassword123

    public class LogInUserCommand : ICommand
    {
        private readonly IUserServices userService;

        public LogInUserCommand(IUserServices userService)
        {
            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            string username = parameters[1];
            string password = parameters[2];

            if (userService.ValidateUser())
            {
                throw new Exception("There is a logged in user!");
            }
            else
            {
                userService.LogInUser(username, password);
            }
            return "User logged in successfully.";
        }
    }
}
